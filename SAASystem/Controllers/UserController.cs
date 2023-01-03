using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContext _userContext;
        public UserController(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public IActionResult Index()
        {
            UserViewModel.IndexViewModel viewModel = new UserViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            UserViewModel.ListViewModel list = new UserViewModel.ListViewModel();
            list.Status = param;
            list.UserContextModelEnumerable = _userContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            UserContextModel contextModel = _userContext.Select(id);
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
            UserContextModel contextModel = _userContext.Select(id);
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
            _userContext.Update(contextModel);
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
            UserBuilder builder = new UserBuilder();
            UserContextModel contextModel = builder
                .SetUsername(insertViewModel.Form.Username)
                .SetEmail(insertViewModel.Form.Email)
                .SetPhoneNo(insertViewModel.Form.PhoneNo)
                .SetSurname(insertViewModel.Form.Surname)
                .SetGivenName(insertViewModel.Form.GivenName)
                .SetAddress(insertViewModel.Form.Address)
                .Build();
            _userContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            UserContextModel contextModel = _userContext.Select(id);
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
                _userContext.Delete(deleteViewModel.UserContextModel.UserId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Insert" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "List" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            return itemModelList;
        }
    }
}
