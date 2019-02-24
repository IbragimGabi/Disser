﻿using TestApplication.Data;
using TestApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StateFlowFramework;
using System.Diagnostics;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        private IFlowService flowService;
        private readonly TestRepository testRepository;
        private readonly UserManager<ApplicationUser> userManager;

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


        public IActionResult Test2(string flow, string condition)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            string state = flowService.ChangeState(user, flow, condition);
            var tasks = testRepository.GetTestsByFlowId(state, user.UserTests.Find(_ => _.TestId == 0).TestId);
            ViewData["Tasks"] = tasks;
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