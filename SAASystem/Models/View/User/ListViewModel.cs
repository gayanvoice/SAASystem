using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Models.View.User
{
    public class ListViewModel
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public IEnumerable<UserContextModel> UserContextModelEnumerable { get; set; }
    }
}