using SAASystem.Models.Component.Home;
using System.Collections.Generic;

namespace SAASystem.Models.View.Home
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
    }
}