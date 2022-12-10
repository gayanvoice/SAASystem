//`StockId` int (11) NOT NULL AUTO_INCREMENT
//`ApartmentId` int (11) NOT NULL
//`Name` varchar(20) NOT NULL
//`IsActive` tinyint(1) NOT NULL
public class StockContextModel
{
    public int StockId { get; set; }
    public int ApartmentId{ get; set; }
    public string Name{ get; set; }
    public bool IsActive { get; set; }
}