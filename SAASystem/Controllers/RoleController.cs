﻿using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Enum;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;

namespace SAASystem.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            string username = Request.Cookies[UserCookieEnum.A_SYSTEM_USERNAME.ToString()];
            string role = Request.Cookies[UserCookieEnum.A_SYSTEM_ROLE.ToString()];
            if (username is null || role is null)
            {
                return RedirectToAction("Index", "Home", new { Param = "NotLoggedIn" });
            }
            else
            {
                if (role.Equals(UserRoleEnum.STAFF.ToString()))
                {
                    RoleViewModel.IndexViewModel viewModel = new RoleViewModel.IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = RoleHelper.GetItemComponentModels();
                    return View(viewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { Param = "UnauthorizedAccess" });
                }
            }
        }
        public IActionResult List(string param)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleViewModel.ListViewModel list = new RoleViewModel.ListViewModel();
            list.Status = param;
            list.RoleContextModelEnumerable = roleContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleContextModel contextModel = roleContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            RoleViewModel.ShowViewModel showViewModel = new RoleViewModel.ShowViewModel();
            showViewModel.Form = RoleViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleContextModel contextModel = roleContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                RoleViewModel.EditViewModel editViewModel = new RoleViewModel.EditViewModel();
                editViewModel.Form = RoleViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(RoleHelper.GenerateView(editViewModel));
            }
        }
        [HttpPost]
        public IActionResult Edit(RoleViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(RoleHelper.GenerateView(editViewModel));
            }
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleBuilder builder = new RoleBuilder();
            RoleContextModel contextModel = builder
                .SetRoleId(editViewModel.Form.RoleId)
                .SetName(editViewModel.Form.Name)
                .Build();
            roleContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            RoleViewModel.InsertViewModel insertViewModel = new RoleViewModel.InsertViewModel();
            insertViewModel.Form = new RoleViewModel.InsertViewModel.FormViewModel();
            return View(RoleHelper.GenerateView(insertViewModel));
        }
        [HttpPost]
        public IActionResult Insert(RoleViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(RoleHelper.GenerateView(insertViewModel));
            }
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleBuilder builder = new RoleBuilder();
            RoleContextModel contextModel = builder
                .SetName(insertViewModel.Form.Name)
                .Build();
            roleContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }
        public IActionResult Delete(int id)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleContextModel contextModel = roleContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            RoleViewModel.DeleteViewModel viewModel = new RoleViewModel.DeleteViewModel();
            viewModel.RoleContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(RoleViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
                roleContextSingleton.Delete(deleteViewModel.RoleContextModel.RoleId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}