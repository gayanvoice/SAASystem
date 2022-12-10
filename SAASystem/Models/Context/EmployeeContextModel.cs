//`EmployeeId` int (11) NOT NULL AUTO_INCREMENT
//`UserId` int (11) NOT NULL
//`RoleId` int (11) NOT NULL
//`IsActive` tinyint(1) NOT NULL
public class EmployeeContextModel
{
    public int EmployeeId { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public bool IsActive { get; set; }
}