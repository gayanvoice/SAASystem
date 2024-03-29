﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class PropertyViewModel
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
                [Display(Name = "Property Id")]
                public int PropertyId { get; set; }

                [Display(Name = "Name")]
                public string Name { get; set; }

                [Display(Name = "Address")]
                public string Address { get; set; }

                [Display(Name = "Street")]
                public string Street { get; set; }

                [Display(Name = "City")]
                public string City { get; set; }

                [Display(Name = "PostCode")]
                public string PostCode { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    PropertyContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PropertyId = contextModel.PropertyId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.Address = contextModel.Address;
                    formViewModel.Street = contextModel.Street;
                    formViewModel.City = contextModel.City;
                    formViewModel.PostCode = contextModel.PostalCode;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<PropertyContextModel> PropertyContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public PropertyContextModel PropertyContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Property Id")]
                public int PropertyId { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "Name")]
                public string Name { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "Address")]
                public string Address { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "Street")]
                public string Street { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "City")]
                public string City { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "PostCode")]
                public string PostCode { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    PropertyContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.PropertyId = contextModel.PropertyId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.Address = contextModel.Address;
                    formViewModel.Street = contextModel.Street;
                    formViewModel.City = contextModel.City;
                    formViewModel.PostCode = contextModel.PostalCode;
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
                [StringLength(45)]
                [Display(Name = "Name")]
                public string Name { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "Address")]
                public string Address { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "Street")]
                public string Street { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "City")]
                public string City { get; set; }

                [Required]
                [StringLength(45)]
                [Display(Name = "PostCode")]
                public string PostCode { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}