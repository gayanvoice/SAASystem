using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class RoomControllerHelper
    {
        public static IEnumerable<SelectListItem> GetIEnumerableSelectListItem<TEnum>()
         where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            foreach (TEnum tEnum in System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                string value = tEnum.ToString();
                selectListItemList.Add(new SelectListItem() { Text = value, Value = value });
            }
            return selectListItemList;
        }
        public static IEnumerable<SelectListItem> FromApartmentModelEnumerable(
            IEnumerable<ApartmentContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            if (enumerable.Count() > 0)
            {
                foreach (ApartmentContextModel contextModel in enumerable)
                {
                    selectListItemList.Add(new SelectListItem()
                    {
                        Text = contextModel.ApartmentId + " - " + contextModel.Code,
                        Value = contextModel.ApartmentId.ToString()
                    });
                }
            }
            else
            {
                selectListItemList.Add(new SelectListItem()
                {
                    Text = "No Items in Apartment Table",
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