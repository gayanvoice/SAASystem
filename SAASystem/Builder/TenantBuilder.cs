using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class TenantBuilder
    {
        private TenantContextModel _contextModel = new TenantContextModel();
        public TenantBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new TenantContextModel();
        }
        public void Set(TenantContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public TenantBuilder SetTenantId(int tenantId)
        {
            _contextModel.TenantId = tenantId;
            return this;
        }
        public TenantBuilder SetUserId(int userId)
        {
            _contextModel.UserId = userId;
            return this;
        }
        public TenantContextModel Build()
        {
            TenantContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}