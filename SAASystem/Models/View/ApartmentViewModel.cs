using SAASystem.Models.Component;
using SAASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class ApartmentViewModel
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
                [Display(Name = "Apartment Id")]
                public int ApartmentId { get; set; }

                [Display(Name = "Property Id")]
                public int PropertyId { get; set; }

                [Display(Name = "Suite Id")]
                public int SuiteId { get; set; }

                [Display(Name = "Code")]
                public string Code { get; set; }

                public static FormViewModel FromContextModel(
                    ApartmentContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ApartmentId = contextModel.ApartmentId;
                    formViewModel.PropertyId = contextModel.PropertyId;
                    formViewModel.SuiteId = contextModel.SuiteId;
                    formViewModel.Code = contextModel.Code;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<ApartmentContextModel> ApartmentContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public ApartmentContextModel ApartmentContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> PropertyEnumerable { get; set; }
            public IEnumerable<SelectListItem> SuiteEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Apartment Id")]
                public int ApartmentId { get; set; }

                [Required]
                [Display(Name = "Property Id")]
                public int PropertyId { get; set; }

                [Required]
                [Display(Name = "Suite Id")]
                public int SuiteId { get; set; }

                [Required]
                [StringLength(10)]
                [Display(Name = "Code")]
                public string Code { get; set; }

                public static FormViewModel FromContextModel(
                    ApartmentContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ApartmentId = contextModel.ApartmentId;
                    formViewModel.PropertyId = contextModel.PropertyId;
                    formViewModel.SuiteId = contextModel.SuiteId;
                    formViewModel.Code = contextModel.Code;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> PropertyEnumerable { get; set; }
            public IEnumerable<SelectListItem> SuiteEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Property Id")]
                public int PropertyId { get; set; }

                [Required]
                [Display(Name = "Suite Id")]
                public int SuiteId { get; set; }

                [Required]
                [StringLength(10)]
                [Display(Name = "Code")]
                public string Code { get; set; }
            }
        }
    }
}