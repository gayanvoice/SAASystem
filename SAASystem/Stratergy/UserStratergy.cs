using SAASystem.Models.Component;
using System.Collections.Generic;

namespace SAASystem.Stratergy
{
    public class UserStratergy
    {
        public abstract class Strategy
        {
            public abstract IEnumerable<ItemComponentModel> Module();
        }
        public class ManagerStratergy : Strategy
        {
            public override IEnumerable<ItemComponentModel> Module()
            {
                List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
                itemModelList.Add(new ItemComponentModel()
                {
                    Name = "User",
                    Route = new ItemComponentModel.RouteModel() { Controller = "User", Action = "Index" },
                    ImageUrl = "/pics/user.jpg"
                });
                return itemModelList;
            }
        }
        public class StudentStratergy : Strategy
        {
            public override IEnumerable<ItemComponentModel> Module()
            {
                List<ItemComponentModel> itemModelList = new List<ItemComponentModel>();
                itemModelList.Add(new ItemComponentModel()
                {
                    Name = "Student",
                    Route = new ItemComponentModel.RouteModel() { Controller = "Home", Action = "Student" },
                    ImageUrl = "/pics/user.jpg"
                });
                return itemModelList;
            }
        }
        public class StaffStratergy : Strategy
        {
            public override IEnumerable<ItemComponentModel> Module()
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
                return itemModelList;
            }
        }
        public class Context
        {
            Strategy strategy;
            public Context(Strategy strategy)
            {
                this.strategy = strategy;
            }
            public IEnumerable<ItemComponentModel> ContextInterface()
            {
                return strategy.Module();
            }
        }
    }
}
