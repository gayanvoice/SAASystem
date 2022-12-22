using SAASystem.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace SAASystem.Models.View.User
{
    public class ShowViewModel
    {

        public string Title { get; set; }
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }
        public string Address { get; set; }
        public static ShowViewModel FromUserContextModel(UserContextModel userContextModel)
        {
            ShowViewModel showViewModel = new ShowViewModel();
            showViewModel.UserId = userContextModel.UserId;
            showViewModel.Username = userContextModel.Username;
            showViewModel.Email = userContextModel.PhoneNo;
            showViewModel.PhoneNo = userContextModel.PhoneNo;
            showViewModel.Surname = userContextModel.Surname;
            showViewModel.GivenName = userContextModel.GivenName;
            showViewModel.Address = userContextModel.Address;
            return showViewModel;
        }
    }
}