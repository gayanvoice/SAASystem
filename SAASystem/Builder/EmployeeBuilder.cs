using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class EmployeeBuilder
    {
        private EmployeeContextModel _contextModel = new EmployeeContextModel();
        public EmployeeBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new EmployeeContextModel();
        }
        public void Set(EmployeeContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public EmployeeBuilder SetEmployeeId(int employeeId)
        {
            _contextModel.EmployeeId = employeeId;
            return this;
        }
        public EmployeeBuilder SetUserId(int userId)
        {
            _contextModel.UserId = userId;
            return this;
        }
        public EmployeeBuilder SetRoleId(int roleId)
        {
            _contextModel.RoleId = roleId;
            return this;
        }
        public EmployeeBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public EmployeeContextModel Build()
        {
            EmployeeContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}