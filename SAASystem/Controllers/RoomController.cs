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
    public class RoomController : Controller
    {
        private readonly IApartmentContext _apartmentContext;
        private readonly IRoomContext _roomContext;
        public RoomController(
            IApartmentContext apartmentContext,
            IRoomContext roomContext)
        {
            _apartmentContext = apartmentContext;
            _roomContext = roomContext;
        }
        public IActionResult Index()
        {
            RoomViewModel.IndexViewModel viewModel = new RoomViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            RoomViewModel.ListViewModel list = new RoomViewModel.ListViewModel();
            list.Status = param;
            list.RoomContextModelEnumerable = _roomContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            RoomContextModel contextModel = _roomContext.Select(id);
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
            RoomContextModel contextModel = _roomContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
                RoomViewModel.EditViewModel editViewModel = new RoomViewModel.EditViewModel();
                editViewModel.ApartmentEnumerable = RoomHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
                editViewModel.StatusEnumerable = RoomHelper.GetIEnumerableSelectListItem<RoomStatusEnum>();
                editViewModel.Form = RoomViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
                editViewModel.ApartmentEnumerable = RoomHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
                editViewModel.StatusEnumerable = RoomHelper.GetIEnumerableSelectListItem<RoomStatusEnum>();
                return View(editViewModel);
            }
            RoomBuilder builder = new RoomBuilder();
            RoomContextModel contextModel = builder
                .SetRoomId(editViewModel.Form.RoomId)
                .SetApartmentId(editViewModel.Form.ApartmentId)
                .SetStatus(editViewModel.Form.Status)
                .Build();
            _roomContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            RoomViewModel.InsertViewModel insertViewModel = new RoomViewModel.InsertViewModel();
            IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
            insertViewModel.ApartmentEnumerable = RoomHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
            insertViewModel.StatusEnumerable = RoomHelper.GetIEnumerableSelectListItem<RoomStatusEnum>();
            insertViewModel.Form = new RoomViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(RoomViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = _apartmentContext.SelectAll();
                insertViewModel.ApartmentEnumerable = RoomHelper.FromApartmentModelEnumerable(apartmentContextModelEnumerable);
                insertViewModel.StatusEnumerable = RoomHelper.GetIEnumerableSelectListItem<RoomStatusEnum>();
                return View(insertViewModel);
            }
            RoomBuilder builder = new RoomBuilder();
            RoomContextModel contextModel = builder
                .SetApartmentId(insertViewModel.Form.ApartmentId)
                .SetStatus(insertViewModel.Form.Status)
                .Build();
            _roomContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            RoomContextModel contextModel = _roomContext.Select(id);
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
                _roomContext.Delete(deleteViewModel.RoomContextModel.RoomId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Room", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Room", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}
