using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Helper
{
    public class ApartmentHelper
    {
        public static IEnumerable<SelectListItem> FromPropertyModelEnumerable(
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
        public static IEnumerable<SelectListItem> FromSuiteModelEnumerable(
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
    }
}