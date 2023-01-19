using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Enum;
using SAASystem.Models.Component;
using SAASystem.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class RoleHelper
    {
        public static RoleViewModel.EditViewModel GenerateView(RoleViewModel.EditViewModel editViewModel)
        {
            editViewModel.StatusEnumerable = FromEnum<RoleStatusEnum>();
            return editViewModel;
        }
        public static RoleViewModel.InsertViewModel GenerateView(RoleViewModel.InsertViewModel insertViewModel)
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Role", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Role", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}