using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface ITenantContext
    {
        int Delete(int tenantId);
        int Insert(TenantContextModel tenantContextModel);
        TenantContextModel Select(int tenantId);
        IEnumerable<TenantContextModel> SelectAll();
        int Update(TenantContextModel tenantContextModel);
    }
}