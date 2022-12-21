namespace SAASystem.Strategy
{
    public class TenantUserModel : IUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string Address { get; set; }
    }
}