using SAASystem.Models.Component;
using System.Collections.Generic;

namespace SAASystem.Helper
{
    public class HomeHelper
    {
        public static IEnumerable<ItemComponentModel> GetIndexItemComponentModels()
        {
            List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Apartment",
                Route = new ItemComponentModel.RouteModel() { Controller = "Apartment", Action = "Index" },
                ImageUrl = "/pics/apartment.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Contract",
                Route = new ItemComponentModel.RouteModel() { Controller = "Contract", Action = "Index" },
                ImageUrl = "/pics/contract.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Employee",
                Route = new ItemComponentModel.RouteModel() { Controller = "Employee", Action = "Index" },
                ImageUrl = "/pics/employee.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Property",
                Route = new ItemComponentModel.RouteModel() { Controller = "Property", Action = "Index" },
                ImageUrl = "/pics/property.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Role",
                Route = new ItemComponentModel.RouteModel() { Controller = "Role", Action = "Index" },
                ImageUrl = "/pics/role.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Room",
                Route = new ItemComponentModel.RouteModel() { Controller = "Room", Action = "Index" },
                ImageUrl = "/pics/room.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Stock",
                Route = new ItemComponentModel.RouteModel() { Controller = "Stock", Action = "Index" },
                ImageUrl = "/pics/stock.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Suite",
                Route = new ItemComponentModel.RouteModel() { Controller = "Suite", Action = "Index" },
                ImageUrl = "/pics/suite.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "Tenant",
                Route = new ItemComponentModel.RouteModel() { Controller = "Tenant", Action = "Index" },
                ImageUrl = "/pics/tenant.jpg"
            });
            itemModelList.Add(new ItemComponentModel()
            {
                Name = "User",
                Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Index" },
                ImageUrl = "/pics/user.jpg"
            });
            return itemModelList;
        }
    }
}