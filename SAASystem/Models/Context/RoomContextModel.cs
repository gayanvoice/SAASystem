//`RoomId` int (11) NOT NULL AUTO_INCREMENT
//`ApartmentId` int (11) NOT NULL
//`Status` tinyint(1) NOT NULL
public class RoomContextModel
{
    public int RoomId { get; set; }
    public int ApartmentId { get; set; }
    public bool Status { get; set; }
}