using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class EmployeeHelper
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
        public static IEnumerable<SelectListItem> FromUserModelEnumerable(
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
                    Text = "No Items in User Table",
                    Value = null
                });
            }
            return selectListItemList;
        }
        public static IEnumerable<SelectListItem> FromTenantModelEnumerable(
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
    }
}