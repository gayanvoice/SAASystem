using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public interface ITenantContext
    {
        TenantModel Select(int userId);
        IEnumerable<TenantModel> SelectAll();
        int Insert(int userId);
        int Update(int tenantId, int userId);
        int Delete(int tenantId);
    }
}