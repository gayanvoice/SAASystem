using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IRoleContext
    {
        int Delete(int roleId);
        int Insert(RoleContextModel roleContextModel);
        RoleContextModel Select(int roleId);
        IEnumerable<RoleContextModel> SelectAll();
        int Update(RoleContextModel roleContextModel);
    }
}