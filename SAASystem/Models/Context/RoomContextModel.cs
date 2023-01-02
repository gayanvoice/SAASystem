//`RoomId` int (11) NOT NULL AUTO_INCREMENT
//`ApartmentId` int (11) NOT NULL
//`Status` varchar(10) NOT NULL
namespace SAASystem.Models.Context
{
    public class RoomContextModel
    {
        public int RoomId { get; set; }
        public int ApartmentId { get; set; }
        public string Status { get; set; }
    }
}