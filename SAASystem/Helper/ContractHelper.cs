using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class ContractHelper
    {
        public static IEnumerable<SelectListItem> FromRoomModelEnumerable(
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
        public static IEnumerable<SelectListItem> FromTenantModelEnumerable(
                    IEnumerable<TenantContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            if (enumerable.Count() > 0)
            {
                foreach (TenantContextModel contextModel in enumerable)
                {
                    selectListItemList.Add(new SelectListItem()
                    {
                        Text = contextModel.TenantId + " - " + contextModel.UserId,
                        Value = contextModel.TenantId.ToString()
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