//`PropertyId` int (11) NOT NULL AUTO_INCREMENT
//`Name` varchar(45) NOT NULL
//`Address` varchar(45) NOT NULL
//`Street` varchar(45) NOT NULL
//`City` varchar(45) NOT NULL
//`PostalCode` varchar(45) NOT NULL
namespace SAASystem.Models.Context
{
    public class PropertyContextModel
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}