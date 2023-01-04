using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class TenantController : Controller
    {
        public IActionResult Index()
        {
            TenantViewModel.IndexViewModel viewModel = new TenantViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = TenantHelper.GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            TenantContextSingleton tenantContextSingleton = TenantContextSingleton.Instance;
            TenantViewModel.ListViewModel list = new TenantViewModel.ListViewModel();
            list.Status = param;
            list.TenantContextModelEnumerable = tenantContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            TenantContextSingleton tenantContextSingleton = TenantContextSingleton.Instance;
            TenantContextModel contextModel = tenantContextSingleton.Select(id);
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
            TenantContextSingleton tenantContextSingleton = TenantContextSingleton.Instance;
            TenantContextModel contextModel = tenantContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
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
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
                editViewModel.UserEnumerable = TenantHelper.FromUserModelEnumerable(userContextModelEnumerable);
                return View(editViewModel);
            }
            TenantContextSingleton tenantContextSingleton = TenantContextSingleton.Instance;
            TenantBuilder builder = new TenantBuilder();
            TenantContextModel contextModel = builder
                .SetTenantId(editViewModel.Form.TenantId)
                .SetUserId(editViewModel.Form.UserId)
                .Build();
            tenantContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            TenantViewModel.InsertViewModel insertViewModel = new TenantViewModel.InsertViewModel();
            IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
            insertViewModel.UserEnumerable = TenantHelper.FromUserModelEnumerable(userContextModelEnumerable);
            insertViewModel.Form = new TenantViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(TenantViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
                insertViewModel.UserEnumerable = TenantHelper.FromUserModelEnumerable(userContextModelEnumerable);
                return View(insertViewModel);
            }
            TenantContextSingleton tenantContextSingleton = TenantContextSingleton.Instance;
            TenantBuilder builder = new TenantBuilder();
            TenantContextModel contextModel = builder
                .SetUserId(insertViewModel.Form.UserId)
                .Build();
            tenantContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }
        public IActionResult Delete(int id)
        {
            TenantContextSingleton tenantContextSingleton = TenantContextSingleton.Instance;
            TenantContextModel contextModel = tenantContextSingleton.Select(id);
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
                TenantContextSingleton tenantContextSingleton = TenantContextSingleton.Instance;
                tenantContextSingleton.Delete(deleteViewModel.TenantContextModel.TenantId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}