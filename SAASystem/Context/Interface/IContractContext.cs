using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IContractContext
    {
        int Delete(int contractId);
        int Insert(ContractContextModel contractContextModel);
        ContractContextModel Select(int contractId);
        IEnumerable<ContractContextModel> SelectAll();
        int Update(ContractContextModel contractContextModel);
    }
}