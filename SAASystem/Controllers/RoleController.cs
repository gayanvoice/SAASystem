using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;

namespace SAASystem.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            RoleViewModel.IndexViewModel viewModel = new RoleViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = RoleControllerHelper.GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleViewModel.ListViewModel list = new RoleViewModel.ListViewModel();
            list.Status = param;
            list.RoleContextModelEnumerable = roleContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleContextModel contextModel = roleContextSingleton.Select(id);
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
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleContextModel contextModel = roleContextSingleton.Select(id);
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
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleBuilder builder = new RoleBuilder();
            RoleContextModel contextModel = builder
                .SetRoleId(editViewModel.Form.RoleId)
                .SetName(editViewModel.Form.Name)
                .SetWorkHours(editViewModel.Form.WorkHours)
                .SetPayHour(editViewModel.Form.PayHour)
                .Build();
            roleContextSingleton.Update(contextModel);
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
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleBuilder builder = new RoleBuilder();
            RoleContextModel contextModel = builder
                .SetName(insertViewModel.Form.Name)
                .SetWorkHours(insertViewModel.Form.WorkHours)
                .SetPayHour(insertViewModel.Form.PayHour)
                .Build();
            roleContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }
        public IActionResult Delete(int id)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            RoleContextModel contextModel = roleContextSingleton.Select(id);
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
                RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
                roleContextSingleton.Delete(deleteViewModel.RoleContextModel.RoleId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}