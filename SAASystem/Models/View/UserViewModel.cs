using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SAASystem.Models.View
{
    public class UserViewModel
    {
        public class Index{
            public IEnumerable<UserModel> UserModelEnumerable { get; set; }
        }

        public class View
        {
            public UserModel UserModel { get; set; }
        }
        public class Update
        {
            public UserModel UserModel { get; set; }

            [Required]
            [Display(Name = "User Id")]
            public string UserId { get; set; }

            [Required]
            [MaxLength(10)]
            [SpaceValidation]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [MaxLength(40)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Phone]
            [MaxLength(20)]
            [Display(Name = "Phone No")]
            public string PhoneNo { get; set; }

            [Required]
            [MaxLength(40)]
            [Display(Name = "Surname")]
            public string Surname { get; set; }

            [Required]
            [MaxLength(40)]
            [Display(Name = "Given Name")]
            public string GivenName { get; set; }

            [Required]
            [MaxLength(120)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            public class SpaceValidationAttribute:ValidationAttribute
            {
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                {
                    if (value is null)
                    {
                    }
                    else
                    {
                        PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
                        propertyInfo.SetValue(validationContext.ObjectInstance, Regex.Replace(value.ToString().ToLower(), @"\s+", "_"), null);
                    }
                    return ValidationResult.Success;
                }
            }
        }
        public class Insert
        {
            [Required]
            [MaxLength(10)]
            [SpaceValidation]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [MaxLength(40)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Phone]
            [MaxLength(20)]
            [Display(Name = "Phone No")]
            public string PhoneNo { get; set; }

            [Required]
            [MaxLength(40)]
            [Display(Name = "Surname")]
            public string Surname { get; set; }

            [Required]
            [MaxLength(40)]
            [Display(Name = "Given Name")]
            public string GivenName { get; set; }

            [Required]
            [MaxLength(120)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            public class SpaceValidationAttribute : ValidationAttribute
            {
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                {
                    if (value is null)
                    {
                    }
                    else
                    {
                        PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
                        propertyInfo.SetValue(validationContext.ObjectInstance, Regex.Replace(value.ToString().ToLower(), @"\s+", "_"), null);
                    }
                    return ValidationResult.Success;
                }
            }
        }

    }
}