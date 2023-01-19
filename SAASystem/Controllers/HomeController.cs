using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAASystem.Enum;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System;
using static SAASystem.Models.View.HomeViewModel;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = HomeHelper.GetIndexItemComponentModels();
            return View(indexViewModel);
        }
        public IActionResult Login()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            if (username is null)
            {
                LoginViewModel loginViewModel = new LoginViewModel();
                return View(loginViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index), new { Param = "AlreadyLogin" });
            }
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
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
                if (userContextModel.Password.Equals(loginViewModel.Password))
                {
                    if (userContextModel.Status.Equals(UserStatusEnum.ENABLE.ToString()))
                    {
                        var cookieOptions = new CookieOptions
                        {
                            Secure = true,
                            HttpOnly = true,
                            SameSite = SameSiteMode.None,
                            Expires = DateTime.Now.AddDays(1)
                        };
                        Response.Cookies.Append(UserCookieEnum.A_SYSTEM_USERNAME.ToString(), userContextModel.Username, cookieOptions);
                        Response.Cookies.Append(UserCookieEnum.A_SYSTEM_ROLE.ToString(), userContextModel.RoleId.ToString(), cookieOptions);
                        return RedirectToAction(nameof(Index), new { Param = "SuccessLogin" });
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "User status is deactive");
                        return View(loginViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Incorrect password");
                    return View(loginViewModel);
                }
            }
        }
        public IActionResult LogOut()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction(nameof(Login), new { Param = "SuccessLogout" });
        }
    }
}