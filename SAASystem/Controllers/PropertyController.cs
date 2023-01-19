using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;

namespace SAASystem.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            PropertyViewModel.IndexViewModel viewModel = new PropertyViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = PropertyHelper.GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            PropertyViewModel.ListViewModel list = new PropertyViewModel.ListViewModel();
            list.Status = param;
            list.PropertyContextModelEnumerable = propertyContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            PropertyContextModel contextModel = propertyContextSingleton.Select(id);
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
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            PropertyContextModel contextModel = propertyContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                PropertyViewModel.EditViewModel editViewModel = new PropertyViewModel.EditViewModel();
                editViewModel.Form = PropertyViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(PropertyHelper.GenerateView(editViewModel));
            }
        }
        [HttpPost]
        public IActionResult Edit(PropertyViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(PropertyHelper.GenerateView(editViewModel));
            }
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            PropertyBuilder builder = new PropertyBuilder();
            PropertyContextModel contextModel = builder
                .SetPropertyId(editViewModel.Form.PropertyId)
                .SetAddress(editViewModel.Form.Address)
                .SetCity(editViewModel.Form.City)
                .SetName(editViewModel.Form.Name)
                .SetPostalCode(editViewModel.Form.PostCode)
                .SetStreet(editViewModel.Form.Street)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            propertyContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            PropertyViewModel.InsertViewModel insertViewModel = new PropertyViewModel.InsertViewModel();
            insertViewModel.Form = new PropertyViewModel.InsertViewModel.FormViewModel();
            return View(PropertyHelper.GenerateView(insertViewModel));
        }
        [HttpPost]
        public IActionResult Insert(PropertyViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(PropertyHelper.GenerateView(insertViewModel));
            }
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            PropertyBuilder builder = new PropertyBuilder();
            PropertyContextModel contextModel = builder
                .SetAddress(insertViewModel.Form.Address)
                .SetCity(insertViewModel.Form.City)
                .SetName(insertViewModel.Form.Name)
                .SetPostalCode(insertViewModel.Form.PostCode)
                .SetStreet(insertViewModel.Form.Street)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            propertyContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }
        public IActionResult Delete(int id)
        {
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            PropertyContextModel contextModel = propertyContextSingleton.Select(id);
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
                PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
                propertyContextSingleton.Delete(deleteViewModel.PropertyContextModel.PropertyId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}