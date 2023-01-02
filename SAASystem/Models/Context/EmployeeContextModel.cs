//`EmployeeId` int (11) NOT NULL AUTO_INCREMENT
//`UserId` int (11) NOT NULL
//`RoleId` int (11) NOT NULL
//`IsActive` vcarchar(10) NOT NULL
namespace SAASystem.Models.Context
{
    public class EmployeeContextModel
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
    }
}