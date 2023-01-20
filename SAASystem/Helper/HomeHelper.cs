using SAASystem.Enum;
using SAASystem.Models.Component;
using SAASystem.Stratergy;
using System.Collections.Generic;

namespace SAASystem.Helper
{
    public class HomeHelper
    {
        public static IEnumerable<ItemComponentModel> GetIndexItemComponentModels(string role)
        {
            if (role.Equals(UserRoleEnum.MANAGER.ToString()))
            {
                return new UserStratergy
                    .Context(new UserStratergy.ManagerStratergy())
                    .ContextInterface();
            }
            else if (role.Equals(UserRoleEnum.STAFF.ToString()))
            {
                return new UserStratergy
                    .Context(new UserStratergy.StaffStratergy())
                    .ContextInterface();
            }
            else
            {
                return new UserStratergy
                    .Context(new UserStratergy.StudentStratergy())
                    .ContextInterface();
            }

        }
    }
}