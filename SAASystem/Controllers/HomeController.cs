using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAASystem.Enum;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using System;
using static SAASystem.Models.View.HomeViewModel;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            string role = Request.Cookies[UserCookieEnum.A_SYSTEM_ROLE.ToString()];
            if (username is null || role is null)
            {
                return RedirectToAction(nameof(Logout), new { Param = "UnauthorizedRole" });
            }
            else
            {
                IndexViewModel indexViewModel = new IndexViewModel();
                indexViewModel.ItemComponentModelEnumerable = HomeHelper.GetIndexItemComponentModels(role);
                return View(indexViewModel);
            }
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
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
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
                        RoleContextModel roleContextModel = roleContextSingleton.Select(userContextModel.RoleId);
                        Response.Cookies.Append(UserCookieEnum.A_SYSTEM_USERNAME.ToString(), userContextModel.Username, cookieOptions);
                        Response.Cookies.Append(UserCookieEnum.A_SYSTEM_ROLE.ToString(), roleContextModel.Name, cookieOptions);
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
        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction(nameof(Login), new { Param = "SuccessLogout" });
        }
        public IActionResult Account()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            string role = Request.Cookies[UserCookieEnum.A_SYSTEM_ROLE.ToString()];
            if (username is null || role is null)
            {
                return RedirectToAction(nameof(Logout), new { Param = "UnauthorizedRole" });
            }
            else
            {
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                UserContextModel contextModel = userContextSingleton.Select(username);
                if (contextModel is null)
                {
                    return RedirectToAction(nameof(Index), new { Param = "ErrorNoId" });
                }
                AccountViewModel accountViewModel = new AccountViewModel();
                accountViewModel.Form = AccountViewModel.FormViewModel.FromContextModel(contextModel);
                return View(accountViewModel);
            }
        }
        public IActionResult Student()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            string role = Request.Cookies[UserCookieEnum.A_SYSTEM_ROLE.ToString()];
            if (username is null || role is null)
            {
                return RedirectToAction(nameof(Logout), new { Param = "UnauthorizedRole" });
            }
            else
            {
                if (role.Equals(UserRoleEnum.STUDENT.ToString()))
                {
                    UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                    ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
                    UserContextModel userContextModel = userContextSingleton.Select(username);
                    ContractContextModel contextModel = contractContextSingleton.SelectByUserId(userContextModel.UserId);
                    if (contextModel is null)
                    {
                        return RedirectToAction(nameof(Index), new { Param = "ErrorNoContract" });
                    }
                    else
                    {
                        StudentViewModel studentViewModel = new StudentViewModel();
                        studentViewModel.Form = HomeViewModel.StudentViewModel.FormViewModel.FromContextModel(contextModel);
                        return View(studentViewModel);
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Logout), new { Param = "UnauthorizedRole" });
                }
            }
        }
    }
}