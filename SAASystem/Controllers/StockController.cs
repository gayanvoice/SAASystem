using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Enum;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class StockController : Controller
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
                    StockViewModel.IndexViewModel viewModel = new StockViewModel.IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = StockHelper.GetItemComponentModels();
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
            StockContextSingleton stockContextSingleton = StockContextSingleton.Instance;
            StockViewModel.ListViewModel list = new StockViewModel.ListViewModel();
            list.Status = param;
            list.StockContextModelEnumerable = stockContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            StockContextSingleton stockContextSingleton = StockContextSingleton.Instance;
            StockContextModel contextModel = stockContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            StockViewModel.ShowViewModel showViewModel = new StockViewModel.ShowViewModel();
            showViewModel.Form = StockViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            StockContextSingleton stockContextSingleton = StockContextSingleton.Instance;
            StockContextModel contextModel = stockContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                StockViewModel.EditViewModel editViewModel = new StockViewModel.EditViewModel();
                editViewModel.Form = StockViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(StockHelper.GenerateView(editViewModel));
            }
        }
        [HttpPost]
        public IActionResult Edit(StockViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(StockHelper.GenerateView(editViewModel));
            }
            StockContextSingleton stockContextSingleton = StockContextSingleton.Instance;
            StockBuilder builder = new StockBuilder();
            StockContextModel contextModel = builder
                .SetStockId(editViewModel.Form.StockId)
                .SetApartmentId(editViewModel.Form.ApartmentId)
                .SetName(editViewModel.Form.Name)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            stockContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            StockViewModel.InsertViewModel insertViewModel = new StockViewModel.InsertViewModel();
            insertViewModel.Form = new StockViewModel.InsertViewModel.FormViewModel();
            return View(StockHelper.GenerateView(insertViewModel));
        }
        [HttpPost]
        public IActionResult Insert(StockViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(StockHelper.GenerateView(insertViewModel));
            }
            StockContextSingleton stockContextSingleton = StockContextSingleton.Instance;
            StockBuilder builder = new StockBuilder();
            StockContextModel contextModel = builder
                .SetApartmentId(insertViewModel.Form.ApartmentId)
                .SetName(insertViewModel.Form.Name)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            stockContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            StockContextSingleton stockContextSingleton = StockContextSingleton.Instance;
            StockContextModel contextModel = stockContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            StockViewModel.DeleteViewModel viewModel = new StockViewModel.DeleteViewModel();
            viewModel.StockContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(StockViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                StockContextSingleton stockContextSingleton = StockContextSingleton.Instance;
                stockContextSingleton.Delete(deleteViewModel.StockContextModel.StockId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
      
    }
}