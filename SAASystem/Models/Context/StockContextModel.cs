//`StockId` int (11) NOT NULL AUTO_INCREMENT
//`ApartmentId` int (11) NOT NULL
//`Name` varchar(20) NOT NULL
//`IsActive` varchar(10) NOT NULL
namespace SAASystem.Models.Context
{
    public class StockContextModel
    {
        public int StockId { get; set; }
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}