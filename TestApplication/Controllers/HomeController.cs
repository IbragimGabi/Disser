using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StateFlowFramework;
using System.Diagnostics;
using System.Linq;
using TestApplication.Data;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        private IFlowService flowService;
        private readonly TestRepository testRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private Test currentUserTest;

        public HomeController(IFlowService flowService, UserManager<ApplicationUser> userManager, TestRepository testRepository)
        {
            this.flowService = flowService;
            this.userManager = userManager;
            this.testRepository = testRepository;
        }

        public IActionResult Index(string flow)
        {
            return View();
        }

        public IActionResult Test(string flow, string condition)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            string state = flowService.ChangeState(user, flow, condition);
            userManager.UpdateAsync(user).Wait();
            return View(state);
        }

        public IActionResult ChooseTest(int userTestId)
        {
            if (currentUserTest == null)
            {
                var user = userManager.GetUserAsync(HttpContext.User).Result;
                var tests = testRepository.GetTestsByUserId(user.Id);
                ViewData["Tests"] = tests;
                return View("ChooseTest");
            }
            else
            {
                var user = userManager.GetUserAsync(HttpContext.User).Result;
                var test = testRepository.GetTestByTestId(userTestId);
                currentUserTest = test;
                user.CurrentState = 0;
                flowService.InitFlowService(currentUserTest.TestFile);
                return View("StartTest");
            }
        }


        public IActionResult Test2(string flow, string condition)
        {
            if (flow != null)
            {
                var user = userManager.GetUserAsync(HttpContext.User).Result;
                var state = flowService.ChangeState(user, flow, condition);
                var testTasks = testRepository.GetTestByTestId(currentUserTest.TestId).TestTasks.FirstOrDefault(_ => _.FlowStateName == state);
                ViewData["Tasks"] = testTasks;
                userManager.UpdateAsync(user).Wait();
                return View(state);
            }
            else
            {
                var user = userManager.GetUserAsync(HttpContext.User).Result;
                var state = flowService.GetCurrentState(user);
                var testTasks = testRepository.GetTestByTestId(currentUserTest.TestId).TestTasks.FirstOrDefault(_ => _.FlowStateName == state);
                ViewData["Tasks"] = testTasks;
                return View(state);
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
