using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Enum;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using static SAASystem.Models.View.ApartmentViewModel;

namespace SAASystem.Controllers
{
    public class ApartmentController : Controller
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
                    IndexViewModel viewModel = new IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = ApartmentHelper.GetItemComponentModels();
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
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ListViewModel list = new ApartmentViewModel.ListViewModel();
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
            ApartmentContextModel contextModel = apartmentContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                ApartmentViewModel.EditViewModel editViewModel = new ApartmentViewModel.EditViewModel();
                editViewModel.Form = ApartmentViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(ApartmentHelper.GenerateView(editViewModel));
            }
        }
        [HttpPost]
        public IActionResult Edit(ApartmentViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ApartmentHelper.GenerateView(editViewModel));
            }
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel contextModel = builder
                .SetApartmentId(editViewModel.Form.ApartmentId)
                .SetPropertyId(editViewModel.Form.PropertyId)
                .SetSuiteId(editViewModel.Form.SuiteId)
                .SetCode(editViewModel.Form.Code)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            apartmentContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            ApartmentViewModel.InsertViewModel insertViewModel = new ApartmentViewModel.InsertViewModel();
            insertViewModel.Form = new ApartmentViewModel.InsertViewModel.FormViewModel();
            return View(ApartmentHelper.GenerateView(insertViewModel));
        }
        [HttpPost]
        public IActionResult Insert(ApartmentViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ApartmentHelper.GenerateView(insertViewModel));
            }
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel contextModel = builder
                .SetPropertyId(insertViewModel.Form.PropertyId)
                .SetSuiteId(insertViewModel.Form.SuiteId)
                .SetCode(insertViewModel.Form.Code)
                .SetStatus(insertViewModel.Form.Status)
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
