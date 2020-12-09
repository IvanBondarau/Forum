using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forum.Models;
using Microsoft.AspNetCore.Diagnostics;
using Forum.Exceptions;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();


            string message;
            if (exceptionHandlerPathFeature.Error is BusinessException)
            {
                var error = exceptionHandlerPathFeature.Error as BusinessException;
                if (error.Code.Equals(ErrorCode.INVALID_CREDENTIALS))
                {
                    return RedirectToAction("Login", "Account", new { isError = true }); 
                } else
                {
                    message = ErrorHandler.ERROR_MESSAGES[error.Code];
                }
            } else
            {
                message = exceptionHandlerPathFeature.Error.Message;
            }


            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message });
        }
    }
}
