using SAASystem.Models.Component;
using SAASystem.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace SAASystem.Models.View
{
    public class ContractViewModel
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
                [Display(Name = "Contract Id")]
                public int ContractId { get; set; }

                [Display(Name = "Room Id")]
                public int RoomId { get; set; }

                [Display(Name = "Tenant Id")]
                public int TenantId { get; set; }

                [Display(Name = "Date Time Contract From")]
                public DateTime DateTimeContractFrom { get; set; }

                [Display(Name = "Date Time Contract To")]
                public DateTime DateTimeContractTo { get; set; }

                [Display(Name = "Deposit Amount")]
                public double DepositAmount { get; set; }

                [Display(Name = "Payed Amount")]
                public double PayedAmount { get; set; }

                public static FormViewModel FromContextModel(
                  ContractContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ContractId = contextModel.ContractId;
                    formViewModel.RoomId = contextModel.RoomId;
                    formViewModel.TenantId = contextModel.TenantId;
                    formViewModel.DateTimeContractFrom = contextModel.DateTimeContractFrom;
                    formViewModel.DateTimeContractTo = contextModel.DateTimeContractTo;
                    formViewModel.DepositAmount = contextModel.DepositAmount;
                    formViewModel.PayedAmount = contextModel.PayedAmount;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<ContractContextModel> ContractContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public ContractContextModel ContractContextModel { get; set; }
        }
        public class EditViewModel
        {
            public IEnumerable<SelectListItem> RoomEnumerable { get; set; }
            public IEnumerable<SelectListItem> TenantEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Contract Id")]
                public int ContractId { get; set; }

                [Required]
                [Display(Name = "Room Id")]
                public int RoomId { get; set; }

                [Required]
                [Display(Name = "Tenant Id")]
                public int TenantId { get; set; }

                [Required]
                [Display(Name = "Date Time Contract From")]
                public DateTime DateTimeContractFrom { get; set; }

                [Required]
                [Display(Name = "Date Time Contract To")]
                public DateTime DateTimeContractTo { get; set; }

                [Required]
                [Display(Name = "Deposit Amount")]
                public double DepositAmount { get; set; }

                [Required]
                [Display(Name = "Payed Amount")]
                public double PayedAmount { get; set; }

                public static FormViewModel FromContextModel(
                    ContractContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ContractId = contextModel.ContractId;
                    formViewModel.RoomId = contextModel.RoomId;
                    formViewModel.TenantId = contextModel.TenantId;
                    formViewModel.DateTimeContractFrom = contextModel.DateTimeContractFrom;
                    formViewModel.DateTimeContractTo = contextModel.DateTimeContractTo;
                    formViewModel.DepositAmount = contextModel.DepositAmount;
                    formViewModel.PayedAmount = contextModel.PayedAmount;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> RoomEnumerable { get; set; }
            public IEnumerable<SelectListItem> TenantEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Room Id")]
                public int RoomId { get; set; }

                [Required]
                [Display(Name = "Tenant Id")]
                public int TenantId { get; set; }

                [Required]
                [Display(Name = "Date Time Contract From")]
                public DateTime DateTimeContractFrom { get; set; }

                [Required]
                [Display(Name = "Date Time Contract To")]
                public DateTime DateTimeContractTo { get; set; }

                [Required]
                [Display(Name = "Deposit Amount")]
                public double DepositAmount { get; set; }

                [Required]
                [Display(Name = "Payed Amount")]
                public double PayedAmount { get; set; }
            }
        }
    }
}