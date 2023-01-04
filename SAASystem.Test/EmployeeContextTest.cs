using SAASystem.Builder;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test
{
    /// <summary>
    /// EmployeeContextTest.cs executes the tests to check if each database function returns view
    public class EmployeeContextTest
    {
        [Fact]
        public void SelectAll()
        {
            EmployeeContextSingleton contextSingleton = EmployeeContextSingleton.Instance;
            IEnumerable<EmployeeContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(3, contextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int id = 2;
            EmployeeContextSingleton contextSingleton = EmployeeContextSingleton.Instance;
            EmployeeContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.EmployeeId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<EmployeeContextModel> contextEnumerable;
            EmployeeContextModel contextModelTest;
            EmployeeContextModel contextModelLast;
            EmployeeBuilder builder = new EmployeeBuilder();

            contextModelTest = builder
                .SetUserId(1)
                .SetRoleId(3)
                .SetStatus("ACTIVE")
                .Build();

            EmployeeContextSingleton contextSingleton = EmployeeContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.Last();

            bool isSameObject = contextModelTest.UserId.Equals(contextModelLast.UserId);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<EmployeeContextModel> contextEnumerable;
            EmployeeContextModel contextModelLast;
            EmployeeContextModel contextModelTest;

            EmployeeBuilder builder = new EmployeeBuilder();

            EmployeeContextSingleton contextSingleton = EmployeeContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.EmployeeId).First();


            contextModelTest = builder
                .SetEmployeeId(contextModelLast.EmployeeId)
                .SetUserId(1)
                .SetRoleId(3)
                .SetStatus("TEST")
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.Status == contextModelTest.Status);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<EmployeeContextModel> contextEnumerableBeforeDelete;
            IEnumerable<EmployeeContextModel> contextEnumerableAfterDelete;
            EmployeeContextModel contextModel;

            EmployeeContextSingleton contextSingleton = EmployeeContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.EmployeeId).First();
            contextSingleton.Delete(contextModel.EmployeeId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.EmployeeId.Equals(contextModel.EmployeeId));
        }
    }
}