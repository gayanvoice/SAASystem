using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IEmployeeContext
    {
        int Delete(int employeeId);
        int Insert(EmployeeContextModel employeeContextModel);
        EmployeeContextModel Select(int employeeId);
        IEnumerable<EmployeeContextModel> SelectAll();
        int Update(EmployeeContextModel employeeContextModel);
    }
}