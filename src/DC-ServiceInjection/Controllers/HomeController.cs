using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DC_ServiceInjection.Service;

namespace DC_ServiceInjection.Controllers
{
    public class HomeController : Controller
    {
        private IGreetingService _greet;

        public HomeController(IGreetingService greetingService)
        {
            _greet = greetingService;
        }

        public IActionResult Index()
        {
            return View();
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
            return View();
        }

        public IActionResult Greet()
        {
            ViewBag.Message = _greet.Greet();
            return View();
        }


    }
}
