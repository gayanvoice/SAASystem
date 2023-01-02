using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class TenantViewModel
    {
        public IndexViewModel Index { get; set; }
        public ListViewModel List { get; set; }
        public InsertViewModel Insert { get; set; }
        public DeleteViewModel Delete { get; set; }
        public EditViewModel Edit { get; set; }
        public ShowViewModel Show { get; set; }
        public class IndexViewModel
        {
            public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
        }
        public class ShowViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Tenant Id")]
                public int TenantId { get; set; }

                [Display(Name = "Name")]
                public int UserId { get; set; }
                public static FormViewModel FromContextModel(
                    TenantContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.TenantId = contextModel.TenantId;
                    formViewModel.UserId = contextModel.UserId;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<TenantContextModel> TenantContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public TenantContextModel TenantContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> UserEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Tenant Id")]
                public int TenantId { get; set; }

                [Required]
                [Display(Name = "User Id")]
                public int UserId { get; set; }

                public static FormViewModel FromContextModel(
                    TenantContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.TenantId = contextModel.TenantId;
                    formViewModel.UserId = contextModel.UserId;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> UserEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "User Id")]
                public int UserId { get; set; }
            }
        }
    }
}