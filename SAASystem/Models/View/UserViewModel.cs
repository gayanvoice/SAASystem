using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View
{
    public class UserViewModel
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
                [Display(Name = "User Id")]
                public int UserId { get; set; }

                [Display(Name = "Username")]
                public string Username { get; set; }

                [Display(Name = "Email")]
                public string Email { get; set; }

                [Display(Name = "PhoneNo")]
                public string PhoneNo { get; set; }

                [Display(Name = "Surname")]
                public string Surname { get; set; }

                [Display(Name = "GivenName")]
                public string GivenName { get; set; }


                [Display(Name = "Address")]
                public string Address { get; set; }

                public static FormViewModel FromContextModel(
                    UserContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.UserId = contextModel.UserId;
                    formViewModel.Username = contextModel.Username;
                    formViewModel.Email = contextModel.Email;
                    formViewModel.PhoneNo = contextModel.PhoneNo;
                    formViewModel.Surname = contextModel.Surname;
                    formViewModel.GivenName = contextModel.GivenName;
                    formViewModel.Address = contextModel.Address;
                    return formViewModel;
                }
            }
        }
        public class ListViewModel
        {
            public string Status { get; set; }
            public IEnumerable<UserContextModel> UserContextModelEnumerable { get; set; }
        }
        public class DeleteViewModel
        {
            public UserContextModel UserContextModel { get; set; }
        }
        public class EditViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "User Id")]
                public int UserId { get; set; }

                [Required]
                [Display(Name = "Username")]
                public string Username { get; set; }

                [Required]
                [Display(Name = "Email")]
                public string Email { get; set; }

                [Required]
                [Display(Name = "PhoneNo")]
                public string PhoneNo { get; set; }

                [Required]
                [Display(Name = "Surname")]
                public string Surname { get; set; }

                [Required]
                [Display(Name = "GivenName")]
                public string GivenName { get; set; }

                [Required]
                [Display(Name = "Address")]
                public string Address { get; set; }

                public static FormViewModel FromContextModel(
                    UserContextModel contextModel)
                {
                    FormViewModel formViewModel = new FormViewModel();
                    formViewModel.UserId = contextModel.UserId;
                    formViewModel.Username = contextModel.Username;
                    formViewModel.Email = contextModel.Email;
                    formViewModel.PhoneNo = contextModel.PhoneNo;
                    formViewModel.Surname = contextModel.Surname;
                    formViewModel.GivenName = contextModel.GivenName;
                    formViewModel.Address = contextModel.Address;
                    return formViewModel;
                }
            }
        }
        public class InsertViewModel
        {
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [Display(Name = "Username")]
                public string Username { get; set; }

                [Required]
                [Display(Name = "Email")]
                public string Email { get; set; }

                [Required]
                [Display(Name = "PhoneNo")]
                public string PhoneNo { get; set; }

                [Required]
                [Display(Name = "Surname")]
                public string Surname { get; set; }

                [Required]
                [Display(Name = "GivenName")]
                public string GivenName { get; set; }

                [Required]
                [Display(Name = "Address")]
                public string Address { get; set; }
            }
        }
    }
}