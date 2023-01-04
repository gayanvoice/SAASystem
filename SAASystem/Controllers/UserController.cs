using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;

namespace SAASystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel.IndexViewModel viewModel = new UserViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = UserHelper.GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            UserViewModel.ListViewModel list = new UserViewModel.ListViewModel();
            list.Status = param;
            list.UserContextModelEnumerable = userContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            UserContextModel contextModel = userContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            UserViewModel.ShowViewModel showViewModel = new UserViewModel.ShowViewModel();
            showViewModel.Form = UserViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            UserContextModel contextModel = userContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                UserViewModel.EditViewModel editViewModel = new UserViewModel.EditViewModel();
                editViewModel.Form = UserViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            UserBuilder builder = new UserBuilder();
            UserContextModel contextModel = builder
                .SetUserId(editViewModel.Form.UserId)
                .SetUsername(editViewModel.Form.Username)
                .SetEmail(editViewModel.Form.Email)
                .SetPhoneNo(editViewModel.Form.PhoneNo)
                .SetSurname(editViewModel.Form.Surname)
                .SetGivenName(editViewModel.Form.GivenName)
                .SetAddress(editViewModel.Form.Address)
                .Build();
            userContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            UserViewModel.InsertViewModel insertViewModel = new UserViewModel.InsertViewModel();
            insertViewModel.Form = new UserViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(UserViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            UserBuilder builder = new UserBuilder();
            UserContextModel contextModel = builder
                .SetUsername(insertViewModel.Form.Username)
                .SetEmail(insertViewModel.Form.Email)
                .SetPhoneNo(insertViewModel.Form.PhoneNo)
                .SetSurname(insertViewModel.Form.Surname)
                .SetGivenName(insertViewModel.Form.GivenName)
                .SetAddress(insertViewModel.Form.Address)
                .Build();
            userContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            UserContextModel contextModel = userContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            UserViewModel.DeleteViewModel viewModel = new UserViewModel.DeleteViewModel();
            viewModel.UserContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(UserViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                userContextSingleton.Delete(deleteViewModel.UserContextModel.UserId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}