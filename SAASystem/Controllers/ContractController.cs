using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class ContractController : Controller
    {
        public IActionResult Index()
        {
            ContractViewModel.IndexViewModel viewModel = new ContractViewModel.IndexViewModel();
            viewModel.ItemComponentModelEnumerable = ContractHelper.GetItemComponentModels();
            return View(viewModel);
        }
        public IActionResult List(string param)
        {
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            ContractViewModel.ListViewModel list = new ContractViewModel.ListViewModel();
            list.Status = param;
            list.ContractContextModelEnumerable = contractContextSingleton.SelectAll();
            return View(list);
        }
        public IActionResult Show(int id)
        {
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            ContractContextModel contextModel = contractContextSingleton.Select(id);
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
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            ContractContextModel contextModel = contractContextSingleton.Select(id);
            if (contextModel is null)
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorNoId" });
            }
            else
            {
                RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                IEnumerable<RoomContextModel> roomContextModelEnumerable = roomContextSingleton.SelectAll();
                IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
                ContractViewModel.EditViewModel editViewModel = new ContractViewModel.EditViewModel();
                editViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
                editViewModel.UserEnumerable = ContractHelper.FromUserModelEnumerable(userContextModelEnumerable);
                editViewModel.Form = ContractViewModel.EditViewModel.FormViewModel.FromContextModel(contextModel);
                return View(editViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(ContractViewModel.EditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                IEnumerable<RoomContextModel> roomContextModelEnumerable = roomContextSingleton.SelectAll();
                IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
                editViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
                editViewModel.UserEnumerable = ContractHelper.FromUserModelEnumerable(userContextModelEnumerable);
                return View(editViewModel);
            }
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            ContractBuilder builder = new ContractBuilder();
            ContractContextModel contextModel = builder
                .SetContractId(editViewModel.Form.ContractId)
                .SetRoomId(editViewModel.Form.RoomId)
                .SetUserId(editViewModel.Form.UserId)
                .SetDateTimeContractFrom(editViewModel.Form.DateTimeContractFrom)
                .SetDateTimeContractTo(editViewModel.Form.DateTimeContractTo)
                .SetDepositAmount(editViewModel.Form.DepositAmount)
                .SetPayedAmount(editViewModel.Form.PayedAmount)
                .Build();
            contractContextSingleton.Update(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessEdit" });
        }
        public IActionResult Insert()
        {
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            ContractViewModel.InsertViewModel insertViewModel = new ContractViewModel.InsertViewModel();
            IEnumerable<RoomContextModel> roomContextModelEnumerable = roomContextSingleton.SelectAll();
            IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
            insertViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
            insertViewModel.UserEnumerable = ContractHelper.FromUserModelEnumerable(userContextModelEnumerable);
            insertViewModel.Form = new ContractViewModel.InsertViewModel.FormViewModel();
            return View(insertViewModel);
        }
        [HttpPost]
        public IActionResult Insert(ContractViewModel.InsertViewModel insertViewModel)
        {
            if (!ModelState.IsValid)
            {
                RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
                UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
                IEnumerable<RoomContextModel> roomContextModelEnumerable = roomContextSingleton.SelectAll();
                IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
                insertViewModel.RoomEnumerable = ContractHelper.FromRoomModelEnumerable(roomContextModelEnumerable);
                insertViewModel.UserEnumerable = ContractHelper.FromUserModelEnumerable(userContextModelEnumerable);
                return View(insertViewModel);
            }
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            ContractBuilder builder = new ContractBuilder();
            ContractContextModel contextModel = builder
                .SetRoomId(insertViewModel.Form.RoomId)
                .SetUserId(insertViewModel.Form.UserId)
                .SetDateTimeContractFrom(insertViewModel.Form.DateTimeContractFrom)
                .SetDateTimeContractTo(insertViewModel.Form.DateTimeContractTo)
                .SetDepositAmount(insertViewModel.Form.DepositAmount)
                .SetPayedAmount(insertViewModel.Form.PayedAmount)
                .Build();
            contractContextSingleton.Insert(contextModel);
            return RedirectToAction(nameof(List), new { Param = "SuccessInsert" });
        }

        public IActionResult Delete(int id)
        {
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            ContractContextModel contextModel = contractContextSingleton.Select(id);
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
                ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
                contractContextSingleton.Delete(deleteViewModel.ContractContextModel.ContractId);
                return RedirectToAction(nameof(List), new { Param = "SuccessDelete" });
            }
            catch
            {
                return RedirectToAction(nameof(List), new { Param = "ErrorConstraint" });
            }
        }
    }
}
