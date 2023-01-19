using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Enum;
using SAASystem.Models.Component;
using SAASystem.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class SuiteHelper
    {
        public static SuiteViewModel.EditViewModel GenerateView(SuiteViewModel.EditViewModel editViewModel)
        {
            editViewModel.StatusEnumerable = FromEnum<SuiteStatusEnum>();
            return editViewModel;
        }
        public static SuiteViewModel.InsertViewModel GenerateView(SuiteViewModel.InsertViewModel insertViewModel)
        {
            insertViewModel.StatusEnumerable = FromEnum<StockStatusEnum>();
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Suite", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Suite", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}