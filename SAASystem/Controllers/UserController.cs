using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAASystem.Context;
using SAASystem.Helper;
using SAASystem.Models.View;
using System.Linq;

namespace SAASystem.Controllers
{
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
    }
}