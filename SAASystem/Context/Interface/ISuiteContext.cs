using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface ISuiteContext
    {
        int Delete(int suiteId);
        int Insert(SuiteContextModel suiteContextModel);
        SuiteContextModel Select(int suiteId);
        IEnumerable<SuiteContextModel> SelectAll();
        int Update(SuiteContextModel suiteContextModel);
    }
}