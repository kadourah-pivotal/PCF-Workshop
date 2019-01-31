using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab02.Models;
using Microsoft.Extensions.Logging;
using System.Threading;


namespace Lab02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly Random _random;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _random = new Random();
        }



        public IActionResult Index()
        {
            Thread.Sleep(_random.Next(500, 2000));

            _logger.LogCritical("Test Critical message");
            _logger.LogError("Test Error message");
            _logger.LogWarning("Test Warning message");
            _logger.LogInformation("Test Informational message");
            _logger.LogDebug("Test Debug message");
            _logger.LogTrace("Test Trace message");

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
