using Microsoft.AspNetCore.Mvc;
using SAASystem.Models.Component;
using SAASystem.Models.View;
using System.Collections.Generic;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeViewModel.IndexViewModel indexViewModel = new HomeViewModel.IndexViewModel();
            indexViewModel.ItemComponentModelEnumerable = GetIndexItemComponentModels();
            return View(indexViewModel);
        }
        private IEnumerable<ItemComponentModel> GetIndexItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Apartment",
                Route = new ItemComponentModel.RouteModel() { Controller = "Apartment", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "User",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            return itemModelList;
        }
    }
}
