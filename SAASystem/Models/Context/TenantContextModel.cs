//`TenantId` int (11) NOT NULL AUTO_INCREMENT
//`UserId` int (11) NOT NULL
namespace SAASystem.Models.Context
{
    public class TenantContextModel
    {
        public int TenantId { get; set; }
        public int UserId { get; set; }
    }
}