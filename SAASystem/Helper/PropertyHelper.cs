using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.View;
using SAASystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class PropertyHelper
    {
        public static PropertyViewModel.EditViewModel GenerateView(PropertyViewModel.EditViewModel editViewModel)
        {
            editViewModel.StatusEnumerable = FromEnum<PropertyStatusEnum>();
            return editViewModel;
        }
        public static PropertyViewModel.InsertViewModel GenerateView(PropertyViewModel.InsertViewModel insertViewModel)
        {
            insertViewModel.StatusEnumerable = FromEnum<PropertyStatusEnum>();
            return insertViewModel;
        }
        public static IEnumerable<SelectListItem> FromEnum<TEnum>()
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
        public static IEnumerable<ItemComponentModel> GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Insert",
                Route = new ItemComponentModel.RouteModel() { Controller = "Property", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Property", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}