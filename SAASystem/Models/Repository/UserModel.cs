using System;
using System.ComponentModel.DataAnnotations.Schema;

public class UserModel
{
    public string Key { get; set; }
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string Surname { get; set; }
    public string GivenName { get; set; }
    public string Address { get; set; }
    public DateTime LastLogin { get; set; }
}
