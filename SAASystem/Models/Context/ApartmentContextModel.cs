namespace SAASystem.Models.Context
{
    //`ApartmentId` int (11) NOT NULL AUTO_INCREMENT,
    //`PropertyId` int (11) NOT NULL,
    //`SuiteId` int (11) NOT NULL,
    //`Code` varchar(10) NOT NULL,
    public class ApartmentContextModel
    {
        public int ApartmentId { get; set; }
        public int PropertyId { get; set; }
        public int SuiteId { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
    }
}