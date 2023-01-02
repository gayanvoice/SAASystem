using SAASystem.Models.Component;
using System.Collections.Generic;

namespace SAASystem.Models.View
{
    public class HomeViewModel
    {
        public IndexViewModel Index { get; set; }
        public class IndexViewModel
        {
            public IEnumerable<ItemComponentModel> ItemComponentModelEnumerable { get; set; }
        }
    }
}