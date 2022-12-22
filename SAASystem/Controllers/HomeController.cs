using Microsoft.AspNetCore.Mvc;
using SAASystem.Models.Component.Home;
using SAASystem.Models.View.Home;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Title = "Home Page";
            indexViewModel.ItemComponentModelEnumerable = GetItemComponentModels();
            return View(indexViewModel);
        }
        private IEnumerable<ItemComponentModel>  GetItemComponentModels()
        {
            List<ItemComponentModel> itemModelList= new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Apartment",
                Route = new ItemComponentModel.RouteModel() { Controller = "Apartment", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Contract",
                Route = new ItemComponentModel.RouteModel() { Controller = "Contract", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Employee",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Property",
                Route = new ItemComponentModel.RouteModel() { Controller = "Property", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Role",
                Route = new ItemComponentModel.RouteModel() { Controller = "Role", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Room",
                Route = new ItemComponentModel.RouteModel() { Controller = "Room", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Stock",
                Route = new ItemComponentModel.RouteModel() { Controller = "Stock", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Suite",
                Route = new ItemComponentModel.RouteModel() { Controller = "Suite", Action = "Index" },
                ImageUrl = "https://getbootstrap.com/docs/5.2/examples/features/unsplash-photo-1.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Tenant",
                Route = new ItemComponentModel.RouteModel() { Controller = "Tenant", Action = "Index" },
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
