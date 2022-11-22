using SAASystem.Helper;
using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class TenantContext : ITenantContext
    {
        private readonly IMySqlHelper _mySqlHelper;
        public TenantContext(IMySqlHelper mySqlHelper)
        {
            _mySqlHelper = mySqlHelper;
        }
        public int Delete(int tenantId)
        {
            string query = "DELETE FROM tenant WHERE where tenant_id = @tenant_id";
            object param = new { tenant_id = tenantId };
            return _mySqlHelper.Delete(query, param);
        }
        public int Insert(int userId)
        {
            string query = "INSERT INTO tenant (user_id) values (@user_id)";
            object param = new { user_id = userId };
            return _mySqlHelper.Insert(query, param);
        }
        public TenantModel Select(int tenantId)
        {
            string query = "SELECT tenant_id TenantId, user_id UserId FROM tenant WHERE where tenant_id = @tenant_id";
            object param = new { tenant_id = tenantId };
            return _mySqlHelper.Select<TenantModel>(query, param);
        }
        public IEnumerable<TenantModel> SelectAll()
        {
            string query = "SELECT tenant_id TenantId, user_id UserId FROM tenant";
            return _mySqlHelper.SelectAll<TenantModel>(query);
        }
        public int Update(int userId, int tenantId)
        {
            string query = "UPDATE tenant SET user_id = @user_id WHERE tenant_id IN (@tenant_id)";
            object param = new { tenant_id = userId, user_id = tenantId };
            return _mySqlHelper.Update(query, param);
        }
    }
}