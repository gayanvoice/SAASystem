using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAASystem.Context;
using SAASystem.Helper;
using SAASystem.Models.View;
using System;
using System.Linq;

namespace SAASystem.Areas.Moduke.Controllers
{
    [Area("Module")]
    public class UserController : Controller
    {
        private readonly IUserContext _userContext;
        private readonly ICipherHelper _cipherHelper;
        public UserController(
            IUserContext userContext,
            ICipherHelper cipherHelper)
        {
            _userContext = userContext;
            _cipherHelper = cipherHelper;
        }
        public IActionResult Index()
        {
            UserViewModel.Index userViewModel = new UserViewModel.Index();
            userViewModel.UserModelEnumerable = _userContext.SelectAll();
            userViewModel.UserModelEnumerable.ToList()
                .ForEach(user => user.Key = _cipherHelper.Encrypt(user.UserId.ToString()));
            return View(userViewModel);
        }
        public IActionResult Show(string key)
        {
            string userId = _cipherHelper.Decrypt(key);
            UserViewModel.View userViewModel = new UserViewModel.View();
            userViewModel.UserModel = _userContext.Select(int.Parse(userId));
            return View(userViewModel);
        }
        public IActionResult Update(string key)
        {
            string userId = _cipherHelper.Decrypt(key);
            UserViewModel.Update userViewModel = new UserViewModel.Update();
            userViewModel.UserModel = _userContext.Select(int.Parse(userId));
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Update(UserViewModel.Update update)
        {
            if (ModelState.IsValid)
            {
                _userContext.Update(int.Parse(update.UserId), update.Username, update.Email,
                    update.PhoneNo, update.Surname, update.GivenName, update.Address);
                return RedirectToAction("Index", "User");
            }
            update.UserModel = _userContext.Select(int.Parse(update.UserId));
            return View(update);
        }
        public IActionResult Insert()
        {
            UserViewModel.Insert userViewModel = new UserViewModel.Insert();
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Insert(UserViewModel.Insert insert)
        {
            if (ModelState.IsValid)
            {
                _userContext.Insert(insert.Username, insert.Email, insert.PhoneNo, insert.Surname, insert.GivenName, insert.Address, DateTime.Now);
                return RedirectToAction("Index", "User");
            }
            return View(insert);
        }
        public IActionResult Delete(string key)
        {
            string userId = _cipherHelper.Decrypt(key);
            int status = _userContext.Delete(int.Parse(userId));
            return RedirectToAction("Index", "User");
        }
    }
}