using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class TenantController : Controller
    {
        private readonly ITenantContext _tenantContext;
        private readonly IUserContext _userContext;
        public TenantController(ITenantContext tenantContext, IUserContext userContext)
        {
            _tenantContext = tenantContext;
            _userContext = userContext;
        }
        public IActionResult Index()
        {
            TenantViewModel.IndexViewModel viewModel = new TenantViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            TenantViewModel.ListViewModel list = new TenantViewModel.ListViewModel();
            list.Status = param;
            list.TenantContextModelEnumerable = _tenantContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            TenantContextModel contextModel = _tenantContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            TenantViewModel.ShowViewModel showViewModel = new TenantViewModel.ShowViewModel();
            showViewModel.Form = TenantViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            TenantContextModel contextModel = _tenantContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
                TenantViewModel.EditViewModel editViewModel = new TenantViewModel.EditViewModel();
                editViewModel.UserEnumerable = TenantHelper.FromUserModelEnumerable(userContextModelEnumerable);
                editViewModel.Form = TenantViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(TenantViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
                editViewModel.UserEnumerable = TenantHelper.FromUserModelEnumerable(userContextModelEnumerable);
                return View(editViewModel);
            }
            TenantBuilder builder = new TenantBuilder();
            TenantContextModel contextModel = builder
                .SetTenantId(editViewModel.Form.TenantId)
                .SetUserId(editViewModel.Form.UserId)
                .Build();
            _tenantContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            TenantViewModel.InsertViewModel insertViewModel = new TenantViewModel.InsertViewModel();
            IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
            insertViewModel.UserEnumerable = TenantHelper.FromUserModelEnumerable(userContextModelEnumerable);
            insertViewModel.Form = new TenantViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(TenantViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<UserContextModel> userContextModelEnumerable = _userContext.SelectAll();
                insertViewModel.UserEnumerable = TenantHelper.FromUserModelEnumerable(userContextModelEnumerable);
                return View(insertViewModel);
            }
            TenantBuilder builder = new TenantBuilder();
            TenantContextModel contextModel = builder
                .SetUserId(insertViewModel.Form.UserId)
                .Build();
            _tenantContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            TenantContextModel contextModel = _tenantContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            TenantViewModel.DeleteViewModel viewModel = new TenantViewModel.DeleteViewModel();
            viewModel.TenantContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(TenantViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _tenantContext.Delete(deleteViewModel.TenantContextModel.TenantId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Tenant", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Tenant", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}
