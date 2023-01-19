using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class SuiteViewModel
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
                [Display(Name = "Suite Id")]
                public int SuiteId { get; set; }

                [Display(Name = "Name")]
                public string Name { get; set; }

                [Display(Name = "Cpw")]
                public double Cpw { get; set; }

                [Display(Name = "Size")]
                public double Size { get; set; }

                [Display(Name = "Security Deposit")]
                public double SecurityDeposit { get; set; }

                [Display(Name = "Days Available")]
                public int DaysAvailable { get; set; }

                [Display(Name = "Maximum Stay")]
                public int MaximumStay { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    SuiteContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SuiteId = contextModel.SuiteId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.Cpw = contextModel.Cpw;
                    formViewModel.Size = contextModel.Size;
                    formViewModel.SecurityDeposit = contextModel.SecurityDeposit;
                    formViewModel.DaysAvailable = contextModel.DaysAvailable;
                    formViewModel.MaximumStay = contextModel.MaximumStay;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<SuiteContextModel> SuiteContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public SuiteContextModel SuiteContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Suite Id")]
                public int SuiteId { get; set; }

                [Required]
                [StringLength(20)]
                [Display(Name = "Name")]
                public string Name { get; set; }

                [Required]
                [Display(Name = "Cpw")]
                public double Cpw { get; set; }

                [Required]
                [Display(Name = "Size")]
                public double Size { get; set; }

                [Required]
                [Display(Name = "Security Deposit")]
                public double SecurityDeposit { get; set; }

                [Required]
                [Display(Name = "Days Available")]
                public int DaysAvailable { get; set; }

                [Required]
                [Display(Name = "Maximum Stay")]
                public int MaximumStay { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    SuiteContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.SuiteId = contextModel.SuiteId;
                    formViewModel.Name = contextModel.Name;
                    formViewModel.Cpw = contextModel.Cpw;
                    formViewModel.Size = contextModel.Size;
                    formViewModel.SecurityDeposit = contextModel.SecurityDeposit;
                    formViewModel.DaysAvailable = contextModel.DaysAvailable;
                    formViewModel.MaximumStay = contextModel.MaximumStay;
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
                [Display(Name = "Cpw")]
                public double Cpw { get; set; }

                [Required]
                [Display(Name = "Size")]
                public double Size { get; set; }

                [Required]
                [Display(Name = "Security Deposit")]
                public double SecurityDeposit { get; set; }

                [Required]
                [Display(Name = "Days Available")]
                public int DaysAvailable { get; set; }

                [Required]
                [Display(Name = "Maximum Stay")]
                public int MaximumStay { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}