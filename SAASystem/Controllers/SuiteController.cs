using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class SuiteController : Controller
    {
        private readonly ISuiteContext _suiteContext;
        public SuiteController(ISuiteContext suiteContext)
        {
            _suiteContext = suiteContext;
        }
        public IActionResult Index()
        {
            SuiteViewModel.IndexViewModel viewModel = new SuiteViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            SuiteViewModel.ListViewModel list = new SuiteViewModel.ListViewModel();
            list.Status = param;
            list.SuiteContextModelEnumerable = _suiteContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SuiteContextModel contextModel = _suiteContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            SuiteViewModel.ShowViewModel showViewModel = new SuiteViewModel.ShowViewModel();
            showViewModel.Form = SuiteViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            SuiteContextModel contextModel = _suiteContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                SuiteViewModel.EditViewModel editViewModel = new SuiteViewModel.EditViewModel();
                editViewModel.Form = SuiteViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(SuiteViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            SuiteBuilder builder = new SuiteBuilder();
            SuiteContextModel contextModel = builder
                .SetSuiteId(editViewModel.Form.SuiteId)
                .SetName(editViewModel.Form.Name)
                .SetCpw(editViewModel.Form.Cpw)
                .SetSize(editViewModel.Form.Size)
                .SetSecurityDeposite(editViewModel.Form.SecurityDeposit)
                .SetDaysAvailable(editViewModel.Form.DaysAvailable)
                .SetMaximumStay(editViewModel.Form.MaximumStay)
                .Build();
            _suiteContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            SuiteViewModel.InsertViewModel insertViewModel = new SuiteViewModel.InsertViewModel();
            insertViewModel.Form = new SuiteViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(SuiteViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(insertViewModel);
            }
            SuiteBuilder builder = new SuiteBuilder();
            SuiteContextModel contextModel = builder
                .SetName(insertViewModel.Form.Name)
                .SetCpw(insertViewModel.Form.Cpw)
                .SetSize(insertViewModel.Form.Size)
                .SetSecurityDeposite(insertViewModel.Form.SecurityDeposit)
                .SetDaysAvailable(insertViewModel.Form.DaysAvailable)
                .SetMaximumStay(insertViewModel.Form.MaximumStay)
                .Build();
            _suiteContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            SuiteContextModel contextModel = _suiteContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            SuiteViewModel.DeleteViewModel viewModel = new SuiteViewModel.DeleteViewModel();
            viewModel.SuiteContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(SuiteViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _suiteContext.Delete(deleteViewModel.SuiteContextModel.SuiteId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Suite", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Suite", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}
