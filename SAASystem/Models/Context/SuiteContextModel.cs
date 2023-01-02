//`SuiteId` int (11) NOT NULL AUTO_INCREMENT
//`Name` varchar(20) NOT NULL
//`Cpw` double NOT NULL
//`Size` double NOT NULL
//`SecurityDeposit` double NOT NULL
//`DaysAvailable` int (11) NOT NULL
//`MaximumStay` int (11) NOT NULL
namespace SAASystem.Models.Context
{
    public class SuiteContextModel
    {
        public int SuiteId { get; set; }
        public string Name { get; set; }
        public double Cpw { get; set; }
        public double Size { get; set; }
        public double SecurityDeposit { get; set; }
        public int DaysAvailable { get; set; }
        public int MaximumStay { get; set; }
    }
}