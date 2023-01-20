using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Enum;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;

namespace SAASystem.Controllers
{
    public class SuiteController : Controller
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
                    SuiteViewModel.IndexViewModel viewModel = new SuiteViewModel.IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = SuiteHelper.GetItemComponentModels();
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
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            SuiteViewModel.ListViewModel list = new SuiteViewModel.ListViewModel();
            list.Status = param;
            list.SuiteContextModelEnumerable = suiteContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            SuiteContextModel contextModel = suiteContextSingleton.Select(id);
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
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            SuiteContextModel contextModel = suiteContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                SuiteViewModel.EditViewModel editViewModel = new SuiteViewModel.EditViewModel();
                editViewModel.Form = SuiteViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(SuiteHelper.GenerateView(editViewModel));
            }
        }
        [HttpPost]
        public IActionResult Edit(SuiteViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(SuiteHelper.GenerateView(editViewModel));
            }
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            SuiteBuilder builder = new SuiteBuilder();
            SuiteContextModel contextModel = builder
                .SetSuiteId(editViewModel.Form.SuiteId)
                .SetName(editViewModel.Form.Name)
                .SetCpw(editViewModel.Form.Cpw)
                .SetSize(editViewModel.Form.Size)
                .SetSecurityDeposite(editViewModel.Form.SecurityDeposit)
                .SetDaysAvailable(editViewModel.Form.DaysAvailable)
                .SetMaximumStay(editViewModel.Form.MaximumStay)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            suiteContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            SuiteViewModel.InsertViewModel insertViewModel = new SuiteViewModel.InsertViewModel();
            insertViewModel.Form = new SuiteViewModel.InsertViewModel.FormViewModel();
            return View(SuiteHelper.GenerateView(insertViewModel));
        }
        [HttpPost]
        public IActionResult Insert(SuiteViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(SuiteHelper.GenerateView(insertViewModel));
            }
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            SuiteBuilder builder = new SuiteBuilder();
            SuiteContextModel contextModel = builder
                .SetName(insertViewModel.Form.Name)
                .SetCpw(insertViewModel.Form.Cpw)
                .SetSize(insertViewModel.Form.Size)
                .SetSecurityDeposite(insertViewModel.Form.SecurityDeposit)
                .SetDaysAvailable(insertViewModel.Form.DaysAvailable)
                .SetMaximumStay(insertViewModel.Form.MaximumStay)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            suiteContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            SuiteContextModel contextModel = suiteContextSingleton.Select(id);
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
                SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
                suiteContextSingleton.Delete(deleteViewModel.SuiteContextModel.SuiteId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}