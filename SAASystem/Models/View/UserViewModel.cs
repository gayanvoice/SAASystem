using System.Collections.Generic;

namespace SAASystem.Models.View
{
    public class UserViewModel
    {
        public class Index{
            public IEnumerable<UserModel> UserModelEnumerable { get; set; }
        }

        public class View
        {
            public UserModel UserModel { get; set; }
        }
    }
}