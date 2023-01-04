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
        public IActionResult Index()
        {
            ApartmentViewModel.IndexViewModel viewModel = new ApartmentViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = ApartmentHelper.GetItemComponentModels();
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
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            ApartmentContextModel contextModel = apartmentContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<PropertyContextModel> propertyContextModelEnumerable = propertyContextSingleton.SelectAll();
                IEnumerable<SuiteContextModel> suiteContextModelEnumerable = suiteContextSingleton.SelectAll();
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
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            if (!ModelState.IsValid)
            {
                IEnumerable<PropertyContextModel> propertyContextModelEnumerable = propertyContextSingleton.SelectAll();
                IEnumerable<SuiteContextModel> suiteContextModelEnumerable = suiteContextSingleton.SelectAll();
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
            apartmentContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            IEnumerable<PropertyContextModel> propertyContextModelEnumerable = propertyContextSingleton.SelectAll();
            IEnumerable<SuiteContextModel> suiteContextModelEnumerable = suiteContextSingleton.SelectAll();
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
                PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
                SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
                IEnumerable<PropertyContextModel> propertyContextModelEnumerable = propertyContextSingleton.SelectAll();
                IEnumerable<SuiteContextModel> suiteContextModelEnumerable = suiteContextSingleton.SelectAll();
                insertViewModel.PropertyEnumerable = ApartmentHelper.FromPropertyModelEnumerable(propertyContextModelEnumerable);
                insertViewModel.SuiteEnumerable = ApartmentHelper.FromSuiteModelEnumerable(suiteContextModelEnumerable);
                return View(insertViewModel);
            }
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel contextModel = builder
                .SetPropertyId(insertViewModel.Form.PropertyId)
                .SetSuiteId(insertViewModel.Form.SuiteId)
                .SetCode(insertViewModel.Form.Code)
                .Build();
            apartmentContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentContextModel contextModel = apartmentContextSingleton.Select(id);
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
                ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
                apartmentContextSingleton.Delete(deleteViewModel.ApartmentContextModel.ApartmentId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}
