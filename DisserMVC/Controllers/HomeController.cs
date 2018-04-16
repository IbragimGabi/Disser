using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DisserMVC.Models;
using DisserMVC.Services;
using Microsoft.AspNetCore.Identity;

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

        public IActionResult Test(string flow)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            userManager.UpdateAsync(user);
            if (flow == "next")
                return View(flowService.GoToNextState(ref user));
            if (flow == "previous")
                return View(flowService.GoToPreviousState(ref user));
            return View(flowService.GetCurrentState(ref user));
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
