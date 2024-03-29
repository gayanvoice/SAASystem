﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class RoleViewModel
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
                [Display(Name = "Role Id")]
                public int RoleId { get; set; }

                [Display(Name = "Name")]
                public string Name { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    RoleContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.RoleId = contextModel.RoleId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<RoleContextModel> RoleContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public RoleContextModel RoleContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Role Id")]
                public int RoleId { get; set; }

                [Required]
                [StringLength(20)]
                [Display(Name = "Name")]
                public string Name { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    RoleContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.RoleId = contextModel.RoleId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [StringLength(20)]
                [Display(Name = "Name")]
                public string Name { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}