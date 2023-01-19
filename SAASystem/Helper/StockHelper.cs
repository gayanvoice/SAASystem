using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Enum;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Models.View;
using SAASystem.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class StockHelper
    {
        public static StockViewModel.EditViewModel GenerateView(StockViewModel.EditViewModel editViewModel)
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = apartmentContextSingleton.SelectAll();
            editViewModel.ApartmentEnumerable = FromApartmentModelEnumerable(apartmentContextModelEnumerable);
            editViewModel.StatusEnumerable = FromEnum<StockStatusEnum>();
            return editViewModel;
        }
        public static StockViewModel.InsertViewModel GenerateView(StockViewModel.InsertViewModel insertViewModel)
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            IEnumerable<ApartmentContextModel> apartmentContextModelEnumerable = apartmentContextSingleton.SelectAll();
            insertViewModel.ApartmentEnumerable = FromApartmentModelEnumerable(apartmentContextModelEnumerable);
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Stock", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Stock", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}