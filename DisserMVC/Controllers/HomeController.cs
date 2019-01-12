using DisserMVC.Models;
using DisserMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DisserMVC.Controllers
{
    public class HomeController : Controller
    {
        private IFlowService flowService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IFlowService flowService, UserManager<ApplicationUser> userManager)
        {
            this.flowService = flowService;
            this.userManager = userManager;
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
