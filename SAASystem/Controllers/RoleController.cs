using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleContext _roleContext;
        public RoleController(IRoleContext roleContext)
        {
            _roleContext = roleContext;
        }
        public IActionResult Index()
        {
            RoleViewModel.IndexViewModel viewModel = new RoleViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            RoleViewModel.ListViewModel list = new RoleViewModel.ListViewModel();
            list.Status = param;
            list.RoleContextModelEnumerable = _roleContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            RoleContextModel contextModel = _roleContext.Select(id);
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
            RoleContextModel contextModel = _roleContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                RoleViewModel.EditViewModel editViewModel = new RoleViewModel.EditViewModel();
                editViewModel.Form = RoleViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(RoleViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            RoleBuilder builder = new RoleBuilder();
            RoleContextModel contextModel = builder
                .SetRoleId(editViewModel.Form.RoleId)
                .SetName(editViewModel.Form.Name)
                .SetWorkHours(editViewModel.Form.WorkHours)
                .SetPayHour(editViewModel.Form.PayHour)
                .Build();
            _roleContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            RoleViewModel.InsertViewModel insertViewModel = new RoleViewModel.InsertViewModel();
            insertViewModel.Form = new RoleViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(RoleViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            RoleBuilder builder = new RoleBuilder();
            RoleContextModel contextModel = builder
                .SetName(insertViewModel.Form.Name)
                .SetWorkHours(insertViewModel.Form.WorkHours)
                .SetPayHour(insertViewModel.Form.PayHour)
                .Build();
            _roleContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            RoleContextModel contextModel = _roleContext.Select(id);
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
                _roleContext.Delete(deleteViewModel.RoleContextModel.RoleId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Role", Action = "Insert" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Role", Action = "List" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            return itemModelList;
        }
    }
}
