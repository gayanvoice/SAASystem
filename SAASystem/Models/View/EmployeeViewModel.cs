using SAASystem.Models.Component;
using SAASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class EmployeeViewModel
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
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                [Display(Name = "User Id")]
                public int UserId { get; set; }

                [Display(Name = "Role Id")]
                public int RoleId { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    EmployeeContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    formViewModel.UserId = contextModel.UserId;
                    formViewModel.RoleId = contextModel.RoleId;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<EmployeeContextModel> EmployeeContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public EmployeeContextModel EmployeeContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> UserEnumerable { get; set; }
            public IEnumerable<SelectListItem> RoleEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Employee Id")]
                public int EmployeeId { get; set; }

                [Required]
                [Display(Name = "User Id")]
                public int UserId { get; set; }

                [Required]
                [Display(Name = "Role Id")]
                public int RoleId { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    EmployeeContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.EmployeeId = contextModel.EmployeeId;
                    formViewModel.UserId = contextModel.UserId;
                    formViewModel.RoleId = contextModel.RoleId;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> UserEnumerable { get; set; }
            public IEnumerable<SelectListItem> RoleEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "User Id")]
                public int UserId { get; set; }

                [Required]
                [Display(Name = "Role Id")]
                public int RoleId { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}