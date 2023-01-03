using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Enum;
using SAASystem.Helper;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeContext _employeeContext;
        private readonly IUserContext _userContext;
        private readonly IRoleContext _roleContext;
        public EmployeeController(
            IEmployeeContext employeeContext,
            IUserContext userContext,
            IRoleContext roleContext)
        {
            _employeeContext = employeeContext;
            _userContext = userContext;
            _roleContext = roleContext;
        }
        public IActionResult Index()
        {
            EmployeeViewModel.IndexViewModel viewModel = new EmployeeViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            EmployeeViewModel.ListViewModel list = new EmployeeViewModel.ListViewModel();
            list.Status = param;
            list.EmployeeContextModelEnumerable = _employeeContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            EmployeeViewModel.ShowViewModel showViewModel = new EmployeeViewModel.ShowViewModel();
            showViewModel.Form = EmployeeViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
                IEnumerable<RoleContextModel> roleContextModelEnumerable = _roleContext.SelectAll();
                EmployeeViewModel.EditViewModel editViewModel = new EmployeeViewModel.EditViewModel();
                editViewModel.UserEnumerable = EmployeeHelper.FromUserModelEnumerable(userContextModelEnumerable);
                editViewModel.RoleEnumerable = EmployeeHelper.FromRoleModelEnumerable(roleContextModelEnumerable);
                editViewModel.StatusEnumerable = EmployeeHelper.GetIEnumerableSelectListItem<EmployeeStatusEnum>();
                editViewModel.Form = EmployeeViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
                IEnumerable<RoleContextModel> roleContextModelEnumerable = _roleContext.SelectAll();
                editViewModel.UserEnumerable = EmployeeHelper.FromUserModelEnumerable(userContextModelEnumerable);
                editViewModel.RoleEnumerable = EmployeeHelper.FromRoleModelEnumerable(roleContextModelEnumerable);
                editViewModel.StatusEnumerable = EmployeeHelper.GetIEnumerableSelectListItem<EmployeeStatusEnum>();
                return View(editViewModel);
            }
            EmployeeBuilder builder = new EmployeeBuilder();
            EmployeeContextModel contextModel = builder
                .SetEmployeeId(editViewModel.Form.EmployeeId)
                .SetUserId(editViewModel.Form.UserId)
                .SetRoleId(editViewModel.Form.RoleId)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _employeeContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            EmployeeViewModel.InsertViewModel insertViewModel = new EmployeeViewModel.InsertViewModel();
            IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
            IEnumerable<RoleContextModel> roleContextModelEnumerable = _roleContext.SelectAll();
            insertViewModel.UserEnumerable = EmployeeHelper.FromUserModelEnumerable(userContextModelEnumerable);
            insertViewModel.RoleEnumerable = EmployeeHelper.FromRoleModelEnumerable(roleContextModelEnumerable);
            insertViewModel.StatusEnumerable = EmployeeHelper.GetIEnumerableSelectListItem<EmployeeStatusEnum>();
            insertViewModel.Form = new EmployeeViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(EmployeeViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
                IEnumerable<RoleContextModel> roleContextModelEnumerable = _roleContext.SelectAll();
                insertViewModel.UserEnumerable = EmployeeHelper.FromUserModelEnumerable(userContextModelEnumerable);
                insertViewModel.RoleEnumerable = EmployeeHelper.FromRoleModelEnumerable(roleContextModelEnumerable);
                insertViewModel.StatusEnumerable = EmployeeHelper.GetIEnumerableSelectListItem<EmployeeStatusEnum>();
                return View(insertViewModel);
            }
            EmployeeBuilder builder = new EmployeeBuilder();
            EmployeeContextModel contextModel = builder
                .SetUserId(insertViewModel.Form.UserId)
                .SetRoleId(insertViewModel.Form.RoleId)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _employeeContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            EmployeeContextModel contextModel = _employeeContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            EmployeeViewModel.DeleteViewModel viewModel = new EmployeeViewModel.DeleteViewModel();
            viewModel.EmployeeContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _employeeContext.Delete(deleteViewModel.EmployeeContextModel.EmployeeId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}
