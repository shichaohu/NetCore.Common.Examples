using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Common.Examples.Models;
using Common.Ioc;
using IBusinesServices;

namespace NetCore.Common.Examples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var exService = IocContainer.GetInstance().GetService<IExampleService>();
            ViewBag.ExampleText = exService.DoWork("index");
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
