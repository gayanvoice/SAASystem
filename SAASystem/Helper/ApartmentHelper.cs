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
    public class ApartmentHelper
    {
        public static ApartmentViewModel.EditViewModel GenerateView(ApartmentViewModel.EditViewModel editViewModel)
        {
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            IEnumerable<PropertyContextModel> propertyContextModelEnumerable = propertyContextSingleton.SelectAll();
            IEnumerable<SuiteContextModel> suiteContextModelEnumerable = suiteContextSingleton.SelectAll();
            editViewModel.PropertyEnumerable = FromPropertyEnumerable(propertyContextModelEnumerable);
            editViewModel.SuiteEnumerable = FromSuiteEnumerable(suiteContextModelEnumerable);
            editViewModel.StatusEnumerable = FromEnum<ApartmentStatusEnum>();
            return editViewModel;
        }
        public static ApartmentViewModel.InsertViewModel GenerateView(ApartmentViewModel.InsertViewModel insertViewModel)
        {
            PropertyContextSingleton propertyContextSingleton = PropertyContextSingleton.Instance;
            SuiteContextSingleton suiteContextSingleton = SuiteContextSingleton.Instance;
            IEnumerable<PropertyContextModel> propertyContextModelEnumerable = propertyContextSingleton.SelectAll();
            IEnumerable<SuiteContextModel> suiteContextModelEnumerable = suiteContextSingleton.SelectAll();
            insertViewModel.PropertyEnumerable = FromPropertyEnumerable(propertyContextModelEnumerable);
            insertViewModel.SuiteEnumerable = FromSuiteEnumerable(suiteContextModelEnumerable);
            insertViewModel.StatusEnumerable = FromEnum<ApartmentStatusEnum>();
            return insertViewModel;
        }
        private static IEnumerable<SelectListItem> FromEnum<TEnum>()
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
        private static IEnumerable<SelectListItem> FromPropertyEnumerable(
            IEnumerable<PropertyContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            if (enumerable.Count() > 0)
            {
                foreach (PropertyContextModel contextModel in enumerable)
                {
                    selectListItemList.Add(new SelectListItem()
                    {
                        Text = contextModel.Name + " - " + contextModel.PostalCode,
                        Value = contextModel.PropertyId.ToString()
                    });
                }
            }
            else
            {
                selectListItemList.Add(new SelectListItem()
                {
                    Text = "No Items in Property Table",
                    Value = null
                });
            }
            return selectListItemList;
        }
        private static IEnumerable<SelectListItem> FromSuiteEnumerable(
                    IEnumerable<SuiteContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            if (enumerable.Count() > 0)
            {
                foreach (SuiteContextModel contextModel in enumerable)
                {
                    selectListItemList.Add(new SelectListItem()
                    {
                        Text = contextModel.Name,
                        Value = contextModel.SuiteId.ToString()
                    });
                }
            }
            else
            {
                selectListItemList.Add(new SelectListItem()
                {
                    Text = "No Items in Suite Table",
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
                Route = new ItemComponentModel.RouteModel() { Controller = "Apartment", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "Apartment", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}