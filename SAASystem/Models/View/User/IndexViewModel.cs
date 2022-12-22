using SAASystem.Models.Component.User;
using System.Collections.Generic;

namespace SAASystem.Models.View.User
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
    }
}