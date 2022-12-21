using Microsoft.AspNetCore.Mvc;
using SAASystem.Builder;
using SAASystem.Context;
using SAASystem.Models.Context;

namespace SAASystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContext _userContext;
        public UserController(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public IActionResult Insert()
        {
            UserBuilder userBuilder = new UserBuilder();
            UserContextModel userContextModel = userBuilder
                .SetUsername("root")
                .SetEmail("email")
                .SetPhoneNo("011")
                .SetSurname("surname")
                .SetGivenName("given name")
                .SetAddress("address")
                .Build();
            _userContext.Insert(userContextModel);
            return View();
        }

        public IActionResult Update(int userId)
        {
            UserBuilder userBuilder = new UserBuilder();
            userBuilder.Set(_userContext.Select(userId));
            UserContextModel userContextModel = userBuilder.SetAddress("root updated address").Build();
            _userContext.Update(userContextModel);
            return View();
        }
    }
}
