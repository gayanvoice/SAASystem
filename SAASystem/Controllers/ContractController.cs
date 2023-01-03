using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractContext _contractContext;
        private readonly ITenantContext _tenantContext;
        private readonly IRoomContext _roomContext;
        public ContractController(
            IContractContext contractContext,
            ITenantContext tenantContext,
            IRoomContext roomContext)
        {
            _contractContext = contractContext;
            _tenantContext = tenantContext;
            _roomContext = roomContext;
        }
        public IActionResult Index()
        {
            ContractViewModel.IndexViewModel viewModel = new ContractViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            ContractViewModel.ListViewModel list = new ContractViewModel.ListViewModel();
            list.Status = param;
            list.ContractContextModelEnumerable = _contractContext.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            ContractContextModel contextModel = _contractContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }

            ContractViewModel.ShowViewModel showViewModel = new ContractViewModel.ShowViewModel();
            showViewModel.Form = ContractViewModel.ShowViewModel.FormViewModel.FromContextModel(contextModel);
            return View(showViewModel);
        }
        public IActionResult Edit(int id)
        {
            ContractContextModel contextModel = _contractContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                IEnumerable<RoomContextModel> roomContextModelEnumerable = _roomContext.SelectAll();
                IEnumerable<TenantContextModel> tenantContextModelEnumerable = _tenantContext.SelectAll();
                ContractViewModel.EditViewModel editViewModel = new ContractViewModel.EditViewModel();
                editViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
                editViewModel.TenantEnumerable = ContractHelper.FromTenantModelEnumerable(tenantContextModelEnumerable);
                editViewModel.Form = ContractViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(ContractViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<RoomContextModel> roomContextModelEnumerable = _roomContext.SelectAll();
                IEnumerable<TenantContextModel> tenantContextModelEnumerable = _tenantContext.SelectAll();
                editViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
                editViewModel.TenantEnumerable = ContractHelper.FromTenantModelEnumerable(tenantContextModelEnumerable);
                return View(editViewModel);
            }
            ContractBuilder builder = new ContractBuilder();
            ContractContextModel contextModel = builder
                .SetContractId(editViewModel.Form.ContractId)
                .SetRoomId(editViewModel.Form.RoomId)
                .SetTenantId(editViewModel.Form.TenantId)
                .SetDateTimeContractFrom(editViewModel.Form.DateTimeContractFrom)
                .SetDateTimeContractTo(editViewModel.Form.DateTimeContractTo)
                .SetDepositAmount(editViewModel.Form.DepositAmount)
                .SetPayedAmount(editViewModel.Form.PayedAmount)
                .Build();
            _contractContext.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            ContractViewModel.InsertViewModel insertViewModel = new ContractViewModel.InsertViewModel();
            IEnumerable<RoomContextModel> roomContextModelEnumerable = _roomContext.SelectAll();
            IEnumerable<TenantContextModel> tenantContextModelEnumerable = _tenantContext.SelectAll();
            insertViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
            insertViewModel.TenantEnumerable = ContractHelper.FromTenantModelEnumerable(tenantContextModelEnumerable);
            insertViewModel.Form = new ContractViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(ContractViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<RoomContextModel> roomContextModelEnumerable = _roomContext.SelectAll();
                IEnumerable<TenantContextModel> tenantContextModelEnumerable = _tenantContext.SelectAll();
                insertViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
                insertViewModel.TenantEnumerable = ContractHelper.FromTenantModelEnumerable(tenantContextModelEnumerable);
                return View(insertViewModel);
            }
            ContractBuilder builder = new ContractBuilder();
            ContractContextModel contextModel = builder
                .SetRoomId(insertViewModel.Form.RoomId)
                .SetTenantId(insertViewModel.Form.TenantId)
                .SetDateTimeContractFrom(insertViewModel.Form.DateTimeContractFrom)
                .SetDateTimeContractTo(insertViewModel.Form.DateTimeContractTo)
                .SetDepositAmount(insertViewModel.Form.DepositAmount)
                .SetPayedAmount(insertViewModel.Form.PayedAmount)
                .Build();
            _contractContext.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            ContractContextModel contextModel = _contractContext.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            ContractViewModel.DeleteViewModel viewModel = new ContractViewModel.DeleteViewModel();
            viewModel.ContractContextModel = contextModel;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(ContractViewModel.DeleteViewModel deleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteViewModel);
            }
            try
            {
                _contractContext.Delete(deleteViewModel.ContractContextModel.ContractId);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Contract", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Contract", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}
