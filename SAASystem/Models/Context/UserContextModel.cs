namespace SAASystem.Models.Context
{
    //`UserId` int (11) NOT NULL AUTO_INCREMENT
    //`Username` varchar(10) NOT NULL
    //`Email` varchar(40) NOT NULL
    //`PhoneNo` varchar(20) NOT NULL
    //`Surname` varchar(40) NOT NULL
    //`GivenName` varchar(40) NOT NULL
    //`Address` varchar(120) NOT NULL
    public class UserContextModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string Address { get; set; }
    }
}