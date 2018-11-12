using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Lab02.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        public HomeController()
        {
            _logger = LoggingConfig.LoggerFactory.CreateLogger<HomeController>();
        }

        public ActionResult Index()
        {
            var minlvl = GetMinLogLevel(_logger);
            Console.WriteLine($"Minimum level set on _logger: {minlvl}");
            Debug.WriteLine($"Minimum level set on _logger: {minlvl}");
            _logger.LogTrace("This is a {LogLevel} log", LogLevel.Trace.ToString());
            _logger.LogDebug("This is a {LogLevel} log", LogLevel.Debug.ToString());
            _logger.LogInformation("This is a {LogLevel} log", LogLevel.Information.ToString());
            _logger.LogWarning("This is a {LogLevel} log", LogLevel.Warning.ToString());
            _logger.LogError("This is a {LogLevel} log", LogLevel.Error.ToString());
            _logger.LogCritical("This is a {LogLevel} log", LogLevel.Critical.ToString());
            return View();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //Logger.
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private LogLevel GetMinLogLevel(ILogger logger)
        {
            for (var i = 0; i < 6; i++)
            {
                var level = (LogLevel)Enum.ToObject(typeof(LogLevel), i);
                if (logger.IsEnabled(level))
                {
                    return level;
                }
            }

            return LogLevel.None;
        }
    }
}