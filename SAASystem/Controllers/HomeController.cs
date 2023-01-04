using Microsoft.AspNetCore.Mvc;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeViewModel.IndexViewModel indexViewModel = new HomeViewModel.IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = HomeHelper.GetIndexItemComponentModels();
            return View(indexViewModel);
        }
        public IActionResult Login()
        {
            HomeViewModel.LoginViewModel loginViewModel = new HomeViewModel.LoginViewModel();
            return View(loginViewModel);
        }
        [HttpPost]
        public IActionResult Login(HomeViewModel.LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            UserContextModel userContextModel = userContextSingleton.Select(loginViewModel.Username);
            if (userContextModel is null)
            {
                ModelState.AddModelError("Username", "Username does not exist");
                return View(loginViewModel);
            }
            else
            {
                CipherSingleton cipherSingleton = CipherSingleton.Instance;
                if (cipherSingleton.Decrypt(userContextModel.Password).Equals(loginViewModel.Password))
                {
                    return RedirectToAction(nameof(Index), new { Param = "SuccessLogin" });
                }
                else
                {
                    ModelState.AddModelError("Password", "Incorrect password");
                    return View(loginViewModel);
                }
            }
        }
    }
}