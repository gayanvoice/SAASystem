using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAASystem.Context;
using SAASystem.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace SAASystem.Areas.Module.Controllers
{
    [Area("Module")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserContext _userContext;
        private readonly ITenantContext _tenantContext;

        public HomeController(IUserContext userContext,
            ITenantContext tenantContext)
        {
            _userContext = userContext;
            _tenantContext = tenantContext;
        }

        public IActionResult Index()
        {
            IEnumerable<UserModel> userModel =_userContext.SelectAll();
            int status = _tenantContext.Insert(1);
            IEnumerable<TenantModel> tenantModels = _tenantContext.SelectAll();
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
