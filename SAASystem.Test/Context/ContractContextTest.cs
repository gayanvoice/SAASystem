using SAASystem.Builder;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test.Context
{
    /// <summary>
    /// ContractContextTest.cs executes the tests to check if each database function returns view
    public class ContractContextTest
    {
        [Fact]
        public void SelectAll()
        {
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            IEnumerable<ContractContextModel> contractContextEnumerable = contractContextSingleton.SelectAll();
            Assert.Equal(4, contractContextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int contractId = 2;
            ContractBuilder builder = new ContractBuilder();
            ContractContextModel contractContextModelTest = builder
                .SetContractId(contractId)
                .SetRoomId(2)
                .SetTenantId(104)
                .SetDateTimeContractFrom(new DateTime(2022, 01, 01))
                .SetDateTimeContractTo(new DateTime(2023, 01, 01))
                .SetDepositAmount(50)
                .SetPayedAmount(150)
                .Build();
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            ContractContextModel contractContextModel = contractContextSingleton.Select(contractId);
            Assert.True(contractContextModelTest.ContractId.Equals(contractContextModel.ContractId));
        }
        [Fact]
        public void Insert()
        {
            ContractBuilder builder = new ContractBuilder();
            ContractContextModel contractContextModelTest = builder
                .SetRoomId(2)
                .SetTenantId(104)
                .SetDateTimeContractFrom(DateTime.Now)
                .SetDateTimeContractTo(DateTime.Now)
                .SetDepositAmount(50)
                .SetPayedAmount(150)
                .Build();

            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            contractContextSingleton.Insert(contractContextModelTest);

            IEnumerable<ContractContextModel> contractContextEnumerable = contractContextSingleton.SelectAll();
            ContractContextModel contractContextModelLast = contractContextEnumerable.Last();

            bool isSameObject = contractContextModelTest.PayedAmount.Equals(contractContextModelLast.PayedAmount);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            IEnumerable<ContractContextModel> contractContextEnumerable = contractContextSingleton.SelectAll();
            ContractContextModel contractContextModel = contractContextEnumerable.OrderByDescending(a => a.ContractId).First();
            ContractBuilder builder = new ContractBuilder();
            ContractContextModel contractContextModelTest = builder
                .SetContractId(contractContextModel.ContractId)
                .SetRoomId(contractContextModel.RoomId)
                .SetTenantId(contractContextModel.TenantId)
                .SetDateTimeContractFrom(contractContextModel.DateTimeContractFrom)
                .SetDateTimeContractTo(contractContextModel.DateTimeContractTo)
                .SetDepositAmount(contractContextModel.DepositAmount)
                .SetPayedAmount(250)
                .Build();

            contractContextSingleton.Update(contractContextModelTest);
            contractContextEnumerable = contractContextSingleton.SelectAll();
            Assert.Contains(contractContextEnumerable, a => a.PayedAmount == contractContextModel.PayedAmount);
        }
        [Fact]
        public void Delete()
        {
            ContractContextSingleton contractContextSingleton = ContractContextSingleton.Instance;
            IEnumerable<ContractContextModel> contractContextEnumerableBeforeDelete = contractContextSingleton.SelectAll();
            ContractContextModel contractContextModel = contractContextEnumerableBeforeDelete.OrderByDescending(a => a.ContractId).First();
            contractContextSingleton.Delete(contractContextModel.ContractId);
            IEnumerable<ContractContextModel> contractContextEnumerableAfterDelete = contractContextSingleton.SelectAll();
            Assert.DoesNotContain(contractContextEnumerableAfterDelete, a => a.ContractId.Equals(contractContextModel.ContractId));
        }
    }
}