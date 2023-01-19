using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class RoleBuilder
    {
        private RoleContextModel _contextModel = new RoleContextModel();
        public RoleBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new RoleContextModel();
        }
        public void Set(RoleContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public RoleBuilder SetRoleId(int roleId)
        {
            _contextModel.RoleId = roleId;
            return this;
        }
        public RoleBuilder SetName(string name)
        {
            _contextModel.Name = name;
            return this;
        }
        public RoleBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public RoleContextModel Build()
        {
            RoleContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}