using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAASystem.Helper;
using SAASystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserContext _userContext;

        public HomeController(ILogger<HomeController> logger, IUserContext userContext)
        {
            _logger = logger;
            _userContext = userContext;
        }

        public IActionResult Index()
        {
            IEnumerable<UserModel> userModel =_userContext.SelectAll();
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
