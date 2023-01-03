using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class TenantHelper
    {
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
    }
}