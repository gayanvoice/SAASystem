namespace SAASystem.Strategy
{
    public class EmployeeUserModel : IUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string Address { get; set; }
        public string Role { get; set;  }
        public bool IsActive { get; set; }
    }
}