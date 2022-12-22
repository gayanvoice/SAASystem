﻿using Microsoft.AspNetCore.Mvc;
using SAASystem.Context;
using SAASystem.Controllers;
using SAASystem.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View.User
{
    public class EditViewModel
    {
        // Configuration Data
        public string Title { get; set; }

        // Form Data
        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(20)]
        public string Email { get; set; }
        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone No")]
        [StringLength(20)]
        public string PhoneNo { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Given Name")]
        [StringLength(20)]
        public string GivenName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        [StringLength(20)]
        public string Address { get; set; }
        public static EditViewModel FromUserContextModel(UserContextModel userContextModel)
        {
            EditViewModel editViewModel = new EditViewModel();
            editViewModel.UserId = userContextModel.UserId;
            editViewModel.Username = userContextModel.Username;
            editViewModel.Email = userContextModel.PhoneNo;
            editViewModel.PhoneNo = userContextModel.PhoneNo;
            editViewModel.Surname = userContextModel.Surname;
            editViewModel.GivenName = userContextModel.GivenName;
            editViewModel.Address = userContextModel.Address;
            return editViewModel;
        }

    }
}