using Microsoft.AspNetCore.Mvc.Rendering;
using SAASystem.Models.Component;
using SAASystem.Models.Context;
using SAASystem.Singleton;
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
                [StringLength(10)]
                [Display(Name = "Username")]
                public string Username { get; set; }


                [Required]
                [StringLength(20)]
                [Display(Name = "Password")]
                public string Password { get; set; }

                [Required]
                [StringLength(40)]
                [Display(Name = "Email")]
                public string Email { get; set; }

                [Required]
                [StringLength(20)]
                [Display(Name = "Phone No")]
                public string PhoneNo { get; set; }

                [Required]
                [StringLength(40)]
                [Display(Name = "Surname")]
                public string Surname { get; set; }

                [Required]
                [StringLength(40)]
                [Display(Name = "Given Name")]
                public string GivenName { get; set; }

                [Required]
                [StringLength(120)]
                [Display(Name = "Address")]
                public string Address { get; set; }

                [Required]
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
        public class InsertViewModel
        {
            public IEnumerable<SelectListItem> RoleEnumerable { get; set; }
            public IEnumerable<SelectListItem> StatusEnumerable { get; set; }
            public FormViewModel Form { get; set; }
            public class FormViewModel
            {
                [Required]
                [StringLength(10)]
                [Display(Name = "Username")]
                public string Username { get; set; }

                [Required]
                [Display(Name = "Role Id")]
                public int RoleId { get; set; }

                [Required]
                [StringLength(20)]
                [Display(Name = "Password")]
                public string Password { get; set; }

                [Required]
                [StringLength(40)]
                [Display(Name = "Email")]
                public string Email { get; set; }

                [Required]
                [StringLength(20)]
                [Display(Name = "Phone No")]
                public string PhoneNo { get; set; }

                [Required]
                [StringLength(40)]
                [Display(Name = "Surname")]
                public string Surname { get; set; }

                [Required]
                [StringLength(40)]
                [Display(Name = "Given Name")]
                public string GivenName { get; set; }

                [Required]
                [StringLength(120)]
                [Display(Name = "Address")]
                public string Address { get; set; }

                [Required]
                [Display(Name = "Status")]
                public string Status { get; set; }
            }
        }
    }
}