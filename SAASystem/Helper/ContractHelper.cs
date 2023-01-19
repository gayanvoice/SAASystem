using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class ContractHelper
    {
        public static ContractViewModel.EditViewModel GenerateView(ContractViewModel.EditViewModel editViewModel)
        {
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            IEnumerable<RoomContextModel> roomContextModelEnumerable = roomContextSingleton.SelectAll();
            IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
            editViewModel.RoomEnumerable = FromRoomEnumerable(roomContextModelEnumerable);
            editViewModel.UserEnumerable = FromUserEnumerable(userContextModelEnumerable);
            return editViewModel;
        }
        public static ContractViewModel.InsertViewModel GenerateView(ContractViewModel.InsertViewModel insertViewModel)
        {
            RoomContextSingleton roomContextSingleton = RoomContextSingleton.Instance;
            UserContextSingleton userContextSingleton = UserContextSingleton.Instance;
            IEnumerable<RoomContextModel> roomContextModelEnumerable = roomContextSingleton.SelectAll();
            IEnumerable<UserContextModel> userContextModelEnumerable = userContextSingleton.SelectAll();
            insertViewModel.RoomEnumerable = FromRoomEnumerable(roomContextModelEnumerable);
            insertViewModel.UserEnumerable = FromUserEnumerable(userContextModelEnumerable);
            return insertViewModel;
        }
        private static IEnumerable<SelectListItem> FromRoomEnumerable(
            IEnumerable<RoomContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            if (enumerable.Count() > 0)
            {
                foreach (RoomContextModel contextModel in enumerable)
                {
                    selectListItemList.Add(new SelectListItem()
                    {
                        Text = contextModel.RoomId + " - " + contextModel.ApartmentId,
                        Value = contextModel.RoomId.ToString()
                    });
                }
            }
            else
            {
                selectListItemList.Add(new SelectListItem()
                {
                    Text = "No Items in Room Table",
                    Value = null
                });
            }
            return selectListItemList;
        }
        private static IEnumerable<SelectListItem> FromUserEnumerable(
                    IEnumerable<UserContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            if (enumerable.Count() > 0)
            {
                foreach (UserContextModel contextModel in enumerable)
                {
                    selectListItemList.Add(new SelectListItem()
                    {
                        Text = contextModel.UserId + " - " + contextModel.Username,
                        Value = contextModel.UserId.ToString()
                    });
                }
            }
            else
            {
                selectListItemList.Add(new SelectListItem()
                {
                    Text = "No Items in Tenant Table",
                    Value = null
                });
            }
            return selectListItemList;
        }
        public static IEnumerable<ItemComponentModel> GetItemComponentModels()
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