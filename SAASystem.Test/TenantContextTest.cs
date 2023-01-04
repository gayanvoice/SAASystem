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
    /// TenantContextTest.cs executes the tests to check if each database function returns view
    public class TenantContextTest
    {
        [Fact]
        public void SelectAll()
        {
            TenantContextSingleton contextSingleton = TenantContextSingleton.Instance;
            IEnumerable<TenantContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(7, contextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int id = 104;
            TenantContextSingleton contextSingleton = TenantContextSingleton.Instance;
            TenantContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.TenantId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<TenantContextModel> contextEnumerable;
            TenantContextModel contextModelTest;
            TenantContextModel contextModelLast;
            TenantBuilder builder = new TenantBuilder();

            contextModelTest = builder
                .SetUserId(2)
                .Build();

            TenantContextSingleton contextSingleton = TenantContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.TenantId).First(); ;

            bool isSameObject = contextModelTest.UserId.Equals(contextModelLast.UserId);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<TenantContextModel> contextEnumerable;
            TenantContextModel contextModelLast;
            TenantContextModel contextModelTest;

            TenantBuilder builder = new TenantBuilder();

            TenantContextSingleton contextSingleton = TenantContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.TenantId).First();


            contextModelTest = builder
                .SetTenantId(contextModelLast.TenantId)
                .SetUserId(8)
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.UserId == contextModelTest.UserId);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<TenantContextModel> contextEnumerableBeforeDelete;
            IEnumerable<TenantContextModel> contextEnumerableAfterDelete;
            TenantContextModel contextModel;

            TenantContextSingleton contextSingleton = TenantContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.TenantId).First();
            contextSingleton.Delete(contextModel.TenantId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.TenantId.Equals(contextModel.TenantId));
        }
    }
}