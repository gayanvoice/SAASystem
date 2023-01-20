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
    public class UserHelper
    {
        public static UserViewModel.EditViewModel GenerateView(UserViewModel.EditViewModel editViewModel)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            IEnumerable<RoleContextModel> roleContextModelEnumerable = roleContextSingleton.SelectAll();
            editViewModel.RoleEnumerable = FromRoleEnumerable(roleContextModelEnumerable);
            editViewModel.StatusEnumerable = FromEnum<UserStatusEnum>();
            return editViewModel;
        }
        public static UserViewModel.InsertViewModel GenerateView(UserViewModel.InsertViewModel insertViewModel)
        {
            RoleContextSingleton roleContextSingleton = RoleContextSingleton.Instance;
            IEnumerable<RoleContextModel> roleContextModelEnumerable = roleContextSingleton.SelectAll();
            insertViewModel.RoleEnumerable = FromRoleEnumerable(roleContextModelEnumerable);
            insertViewModel.StatusEnumerable = FromEnum<UserStatusEnum>();
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
        public static IEnumerable<SelectListItem> FromRoleEnumerable(
            IEnumerable<RoleContextModel> enumerable)
        {
            IList<SelectListItem> selectListItemList = new List<SelectListItem>();
            if (enumerable.Count() > 0)
            {
                foreach (RoleContextModel contextModel in enumerable)
                {
                    selectListItemList.Add(new SelectListItem()
                    {
                        Text = contextModel.RoleId + " - " + contextModel.Name,
                        Value = contextModel.RoleId.ToString()
                    });
                }
            }
            else
            {
                selectListItemList.Add(new SelectListItem()
                {
                    Text = "No Items in Role Table",
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
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Insert" },
                ImageUrl = "/icon/insert.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "List",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "List" },
                ImageUrl = "/icon/list.jpg"
            });
            return itemModelList;
        }
    }
}