using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAASystem.Context;
using SAASystem.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
