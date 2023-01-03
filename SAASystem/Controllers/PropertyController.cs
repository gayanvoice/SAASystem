using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyContext _propertyContext;
        public PropertyController(IPropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }
        public IActionResult Index()
        {
            PropertyViewModel.IndexViewModel viewModel = new PropertyViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            PropertyViewModel.ListViewModel list = new PropertyViewModel.ListViewModel();
            list.Status = param;
            list.PropertyContextModelEnumerable = _propertyContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            PropertyContextModel contextModel = _propertyContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            PropertyViewModel.ShowViewModel showViewModel = new PropertyViewModel.ShowViewModel();
            showViewModel.Form = PropertyViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            PropertyContextModel contextModel = _propertyContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                PropertyViewModel.EditViewModel editViewModel = new PropertyViewModel.EditViewModel();
                editViewModel.Form = PropertyViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(PropertyViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            PropertyBuilder builder = new PropertyBuilder();
            PropertyContextModel contextModel = builder
                .SetPropertyId(editViewModel.Form.PropertyId)
                .SetAddress(editViewModel.Form.Address)
                .SetCity(editViewModel.Form.City)
                .SetName(editViewModel.Form.Name)
                .SetPostalCode(editViewModel.Form.PostCode)
                .SetStreet(editViewModel.Form.Street)
                .Build();
            _propertyContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            PropertyViewModel.InsertViewModel insertViewModel = new PropertyViewModel.InsertViewModel();
            insertViewModel.Form = new PropertyViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(PropertyViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            PropertyBuilder builder = new PropertyBuilder();
            PropertyContextModel contextModel = builder
                .SetAddress(insertViewModel.Form.Address)
                .SetCity(insertViewModel.Form.City)
                .SetName(insertViewModel.Form.Name)
                .SetPostalCode(insertViewModel.Form.PostCode)
                .SetStreet(insertViewModel.Form.Street)
                .Build();
            _propertyContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            PropertyContextModel contextModel = _propertyContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            PropertyViewModel.DeleteViewModel viewModel = new PropertyViewModel.DeleteViewModel();
            viewModel.PropertyContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(PropertyViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _propertyContext.Delete(deleteViewModel.PropertyContextModel.PropertyId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Property", Action = "Insert" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Property", Action = "List" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            return itemModelList;
        }
    }
}
