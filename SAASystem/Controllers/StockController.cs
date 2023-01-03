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
    public class StockController : Controller
    {
        private readonly IStockContext _stockContext;
        private readonly IApartmentContext _apartmentContext;
        public StockController(IStockContext stockContext, IApartmentContext apartmentContext)
        {
            _stockContext = stockContext;
            _apartmentContext = apartmentContext;
        }
        public IActionResult Index()
        {
            StockViewModel.IndexViewModel viewModel = new StockViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            StockViewModel.ListViewModel list = new StockViewModel.ListViewModel();
            list.Status = param;
            list.StockContextModelEnumerable = _stockContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            StockContextModel contextModel = _stockContext.Select(id);
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
            StockContextModel contextModel = _stockContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
                StockViewModel.EditViewModel editViewModel = new StockViewModel.EditViewModel();
                editViewModel.ApartmentEnumerable = StockHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
                editViewModel.StatusEnumerable = StockHelper.GetIEnumerableSelectListItem<StockStatusEnum>();
                editViewModel.Form = StockViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(StockViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
                editViewModel.ApartmentEnumerable = StockHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
                editViewModel.StatusEnumerable = StockHelper.GetIEnumerableSelectListItem<StockStatusEnum>();
                return View(editViewModel);
            }
            StockBuilder builder = new StockBuilder();
            StockContextModel contextModel = builder
                .SetStockId(editViewModel.Form.StockId)
                .SetApartmentId(editViewModel.Form.ApartmentId)
                .SetName(editViewModel.Form.Name)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _stockContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            StockViewModel.InsertViewModel insertViewModel = new StockViewModel.InsertViewModel();
            IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
            insertViewModel.ApartmentEnumerable = StockHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
            insertViewModel.StatusEnumerable = StockHelper.GetIEnumerableSelectListItem<StockStatusEnum>();
            insertViewModel.Form = new StockViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(StockViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
                insertViewModel.ApartmentEnumerable = StockHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
                insertViewModel.StatusEnumerable = StockHelper.GetIEnumerableSelectListItem<StockStatusEnum>();
                return View(insertViewModel);
            }
            StockBuilder builder = new StockBuilder();
            StockContextModel contextModel = builder
                .SetApartmentId(insertViewModel.Form.ApartmentId)
                .SetName(insertViewModel.Form.Name)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _stockContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            StockContextModel contextModel = _stockContext.Select(id);
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
                _stockContext.Delete(deleteViewModel.StockContextModel.StockId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Stock", Action = "Insert" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Stock", Action = "List" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            return itemModelList;
        }
    }
}
