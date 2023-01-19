//`RoleId` int (11) NOT NULL AUTO_INCREMENT
//`Name` varchar(20) NOT NULL
//`WorkHours` double NOT NULL
//`PayHour` double NOT NULL
namespace SAASystem.Models.Context
{
    public class RoleContextModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}