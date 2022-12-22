using SAASystem.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View.User
{
    public class DeleteViewModel
    {
        public string Title { get; set; }
        public FormViewModel Form { get; set; }
        public class FormViewModel
        {
            [Required]
            [Display(Name = "User Id")]
            public int UserId { get; set; }
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }
        }
        public static DeleteViewModel FromUserContextModel(UserContextModel userContextModel)
        {
            FormViewModel formViewModel = new FormViewModel();
            formViewModel.UserId = userContextModel.UserId;
            formViewModel.Username = userContextModel.Username;
            DeleteViewModel deleteViewModel = new DeleteViewModel();
            deleteViewModel.Form = formViewModel;
            return deleteViewModel;
        }
    }
}