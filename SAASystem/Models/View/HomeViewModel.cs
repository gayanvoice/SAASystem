using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class HomeViewModel
    {
        public IndexViewModel Index { get; set; }
        public LoginViewModel Login { get; set; }
        public StudentViewModel Student { get; set; }
        public AccountViewModel Account { get; set; }
        public class IndexViewModel
        {
            public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
        }
        public class LoginViewModel
        {
            [Required]
            public string Username { get; set; }
            [Required]
            public string Password { get; set; }
        }
        public class StudentViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "Contract Id")]
                public int ContractId { get; set; }

                [Display(Name = "Room Id")]
                public int RoomId { get; set; }

                [Display(Name = "User Id")]
                public int UserId { get; set; }

                [Display(Name = "Date Time Contract From")]
                public string DateTimeContractFrom { get; set; }

                [Display(Name = "Date Time Contract To")]
                public string DateTimeContractTo { get; set; }

                [Display(Name = "Deposit Amount")]
                public string DepositAmount { get; set; }

                [Display(Name = "Payed Amount")]
                public string PayedAmount { get; set; }

                public static FormViewModel FromContextModel(
                  ContractContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.ContractId = contextModel.ContractId;
                    formViewModel.RoomId = contextModel.RoomId;
                    formViewModel.UserId = contextModel.UserId;
                    formViewModel.DateTimeContractFrom = contextModel.DateTimeContractFrom.ToShortDateString();
                    formViewModel.DateTimeContractTo = contextModel.DateTimeContractTo.ToShortDateString();
                    formViewModel.DepositAmount = $"£ {contextModel.DepositAmount}";
                    formViewModel.PayedAmount = $"£ {contextModel.PayedAmount}";
                    return formViewModel;
                }
            }
           
        }
        public class AccountViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Display(Name = "User Id")]
                public int UserId { get; set; }

                [Required]
                [Display(Name = "Role Id")]
                public int RoleId { get; set; }

                [Display(Name = "Username")]
                public string Username { get; set; }

                [Display(Name = "Password")]
                public string Password { get; set; }

                [Display(Name = "Email")]
                public string Email { get; set; }

                [Display(Name = "Phone No")]
                public string PhoneNo { get; set; }

                [Display(Name = "Surname")]
                public string Surname { get; set; }

                [Display(Name = "Given Name")]
                public string GivenName { get; set; }

                [Display(Name = "Address")]
                public string Address { get; set; }

                [Display(Name = "Status")]
                public string Status { get; set; }

                public static FormViewModel FromContextModel(
                    UserContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.UserId = contextModel.UserId;
                    formViewModel.RoleId = contextModel.RoleId;
                    formViewModel.Username = contextModel.Username;
                    formViewModel.Password = contextModel.Password;
                    formViewModel.Email = contextModel.Email;
                    formViewModel.PhoneNo = contextModel.PhoneNo;
                    formViewModel.Surname = contextModel.Surname;
                    formViewModel.GivenName = contextModel.GivenName;
                    formViewModel.Address = contextModel.Address;
                    formViewModel.Status = contextModel.Status;
                    return formViewModel;
                }
            }
        }
    }
}