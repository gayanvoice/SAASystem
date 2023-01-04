using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentContext _apartmentContext;
        private readonly IPropertyContext _propertyContext;
        private readonly ISuiteContext _suiteContext;
        public ApartmentController(
            IApartmentContext apartmentContext,
            IPropertyContext propertyContext,
            ISuiteContext suiteContext)
        {
            _apartmentContext = apartmentContext;
            _propertyContext = propertyContext;
            _suiteContext = suiteContext;
        }
        public IActionResult Index()
        {
            ApartmentViewModel.IndexViewModel viewModel = new ApartmentViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentViewModel.ListViewModel list = new ApartmentViewModel.ListViewModel();
            list.Status = param;
            list.ApartmentContextModelEnumerable = apartmentContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentContextModel contextModel = apartmentContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            ApartmentViewModel.ShowViewModel showViewModel = new ApartmentViewModel.ShowViewModel();
            showViewModel.Form = ApartmentViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            ApartmentContextModel contextModel = _apartmentContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<PropertyContextModel> propertyContextModelEnumerable = _propertyContext.SelectAll();
                IEnumerable<SuiteContextModel> suiteContextModelEnumerable = _suiteContext.SelectAll();
                ApartmentViewModel.EditViewModel editViewModel = new ApartmentViewModel.EditViewModel();
                editViewModel.PropertyEnumerable = ApartmentHelper.FromPropertyModelEnumerable(propertyContextModelEnumerable);
                editViewModel.SuiteEnumerable = ApartmentHelper.FromSuiteModelEnumerable(suiteContextModelEnumerable);
                editViewModel.Form = ApartmentViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(ApartmentViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<PropertyContextModel> propertyContextModelEnumerable = _propertyContext.SelectAll();
                IEnumerable<SuiteContextModel> suiteContextModelEnumerable = _suiteContext.SelectAll();
                editViewModel.PropertyEnumerable = ApartmentHelper.FromPropertyModelEnumerable(propertyContextModelEnumerable);
                editViewModel.SuiteEnumerable = ApartmentHelper.FromSuiteModelEnumerable(suiteContextModelEnumerable);
                return View(editViewModel);
            }
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel contextModel = builder
                .SetApartmentId(editViewModel.Form.ApartmentId)
                .SetPropertyId(editViewModel.Form.PropertyId)
                .SetSuiteId(editViewModel.Form.SuiteId)
                .SetCode(editViewModel.Form.Code)
                .Build();
            _apartmentContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            IEnumerable<PropertyContextModel> propertyContextModelEnumerable = _propertyContext.SelectAll();
            IEnumerable<SuiteContextModel> suiteContextModelEnumerable = _suiteContext.SelectAll();
            ApartmentViewModel.InsertViewModel insertViewModel = new ApartmentViewModel.InsertViewModel();
            insertViewModel.PropertyEnumerable = ApartmentHelper.FromPropertyModelEnumerable(propertyContextModelEnumerable);
            insertViewModel.SuiteEnumerable = ApartmentHelper.FromSuiteModelEnumerable(suiteContextModelEnumerable);
            insertViewModel.Form = new ApartmentViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(ApartmentViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<PropertyContextModel> propertyContextModelEnumerable = _propertyContext.SelectAll();
                IEnumerable<SuiteContextModel> suiteContextModelEnumerable = _suiteContext.SelectAll();
                insertViewModel.PropertyEnumerable = ApartmentHelper.FromPropertyModelEnumerable(propertyContextModelEnumerable);
                insertViewModel.SuiteEnumerable = ApartmentHelper.FromSuiteModelEnumerable(suiteContextModelEnumerable);
                return View(insertViewModel);
            }
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel contextModel = builder
                .SetPropertyId(insertViewModel.Form.PropertyId)
                .SetSuiteId(insertViewModel.Form.SuiteId)
                .SetCode(insertViewModel.Form.Code)
                .Build();
            _apartmentContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            ApartmentContextModel contextModel = _apartmentContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            ApartmentViewModel.DeleteViewModel viewModel = new ApartmentViewModel.DeleteViewModel();
            viewModel.ApartmentContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(ApartmentViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _apartmentContext.Delete(deleteViewModel.ApartmentContextModel.ApartmentId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Apartment", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Apartment", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}
