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
    public class RoomController : Controller
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
                    RoomViewModel.IndexViewModel viewModel = new RoomViewModel.IndexViewModel();
                    viewModel.ItemComponentModelEnumerable = RoomHelper.GetItemComponentModels();
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
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            RoomViewModel.ListViewModel list = new RoomViewModel.ListViewModel();
            list.Status = param;
            list.RoomContextModelEnumerable = roomContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            RoomContextModel contextModel = roomContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            RoomViewModel.ShowViewModel showViewModel = new RoomViewModel.ShowViewModel();
            showViewModel.Form = RoomViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            RoomContextModel contextModel = roomContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                RoomViewModel.EditViewModel editViewModel = new RoomViewModel.EditViewModel();
                editViewModel.Form = RoomViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(RoomHelper.GenerateView(editViewModel));
            }
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(RoomHelper.GenerateView(editViewModel));
            }
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            RoomBuilder builder = new RoomBuilder();
            RoomContextModel contextModel = builder
                .SetRoomId(editViewModel.Form.RoomId)
                .SetApartmentId(editViewModel.Form.ApartmentId)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            roomContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            RoomViewModel.InsertViewModel insertViewModel = new RoomViewModel.InsertViewModel();
            insertViewModel.Form = new RoomViewModel.InsertViewModel.FormViewModel();
            return View(RoomHelper.GenerateView(insertViewModel));
        }
        [HttpPost]
        public IActionResult Insert(RoomViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(RoomHelper.GenerateView(insertViewModel));
            }
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            RoomBuilder builder = new RoomBuilder();
            RoomContextModel contextModel = builder
                .SetApartmentId(insertViewModel.Form.ApartmentId)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            roomContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            RoomContextModel contextModel = roomContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            RoomViewModel.DeleteViewModel viewModel = new RoomViewModel.DeleteViewModel();
            viewModel.RoomContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(RoomViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
                roomContextSingleton.Delete(deleteViewModel.RoomContextModel.RoomId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}