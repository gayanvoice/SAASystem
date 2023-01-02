using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context;
using SAASystem.Models.Component.User;
using SAASystem.Models.Context;
using SAASystem.Models.View.User;
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
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Title = "User Page";
            indexViewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(indexViewModel);
        }
        public IActionResult Show(int userId)
        {
            UserContextModel userContextModel = _userContext.Select(userId);
            if (userContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                ShowViewModel showViewModel = ShowViewModel.FromUserContextModel(userContextModel);
                showViewModel.Title = "Show Page";
                return View(showViewModel);
            }
        }
        public IActionResult Add()
        {
            AddViewModel addViewModel = new AddViewModel();
            addViewModel.Title = "Add Page";
            return View(addViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddViewModel addViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addViewModel);
            }
            if (_userContext.Select(addViewModel.Username) is null)
            {
                UserBuilder userBuilder = new UserBuilder();
                UserContextModel userContextModel = userBuilder
                    .SetUsername(addViewModel.Username)
                    .SetEmail(addViewModel.Email)
                    .SetPhoneNo(addViewModel.PhoneNo)
                    .SetSurname(addViewModel.Surname)
                    .SetGivenName(addViewModel.GivenName)
                    .SetAddress(addViewModel.Address)
                    .Build();
                _userContext.Insert(userContextModel);
                return RedirectToAction(nameof(List));
            }
            else
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                return RedirectToAction<ErrorController>(m => m.Show());
                ModelState.AddModelError("Username", "Username is already exist");
                return View(addViewModel);
            }
        }
        public IActionResult Edit(int userId)
        {
            UserContextModel userContextModel = _userContext.Select(userId);
            if (userContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                EditViewModel editViewModel = EditViewModel.FromUserContextModel(userContextModel);
                editViewModel.Title = "Edit Page";
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            UserBuilder userBuilder = new UserBuilder();
            UserContextModel userContextModel = userBuilder
                .SetUsername(editViewModel.Username)
                .SetEmail(editViewModel.Email)
                .SetPhoneNo(editViewModel.PhoneNo)
                .SetSurname(editViewModel.Surname)
                .SetGivenName(editViewModel.GivenName)
                .SetAddress(editViewModel.Address)
                .Build();
            _userContext.Update(userContextModel);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Delete(int userId)
        {
            UserContextModel userContextModel = _userContext.Select(userId);
            if (userContextModel is null)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                DeleteViewModel deleteViewModel = DeleteViewModel.FromUserContextModel(userContextModel);
                deleteViewModel.Title = "Delete Page";
                return View(deleteViewModel);
            }
        }
        [HttpPost]
        public IActionResult Delete(DeleteViewModel deleteViewModel)
        {
            deleteViewModel.Title = "Delete Page";
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _userContext.Delete(deleteViewModel.Form.UserId);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                ModelState.AddModelError("Form.UserId", "UserId has constraints on foriegn key");
                return View(deleteViewModel);
            }
        }
        public IActionResult List()
        {
            ListViewModel userViewModel = new ListViewModel();
            userViewModel.Title = "User List";
            userViewModel.Controller = "User";
            userViewModel.UserContextModelEnumerable = _userContext.SelectAll();
            return View(userViewModel);
        }
        private IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Add",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Add" },
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
