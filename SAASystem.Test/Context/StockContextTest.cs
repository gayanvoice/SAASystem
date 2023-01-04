using SAASystem.Builder;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test.Context
{
    /// <summary>
    /// StockContextTest.cs executes the tests to check if each database function returns view
    public class StockContextTest
    {
        [Fact]
        public void SelectAll()
        {
            StockContextSingleton contextSingleton = StockContextSingleton.Instance;
            IEnumerable<StockContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(6, contextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int id = 3;
            StockContextSingleton contextSingleton = StockContextSingleton.Instance;
            StockContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.StockId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<StockContextModel> contextEnumerable;
            StockContextModel contextModelTest;
            StockContextModel contextModelLast;
            StockBuilder builder = new StockBuilder();

            contextModelTest = builder
                .SetApartmentId(1)
                .SetName("TEST_COOKER")
                .SetStatus("TEST")
                .Build();

            StockContextSingleton contextSingleton = StockContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.Last();

            bool isSameObject = contextModelTest.Status.Equals(contextModelLast.Status);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<StockContextModel> contextEnumerable;
            StockContextModel contextModelLast;
            StockContextModel contextModelTest;

            StockBuilder builder = new StockBuilder();

            StockContextSingleton contextSingleton = StockContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.StockId).First();


            contextModelTest = builder
                .SetStockId(contextModelLast.StockId)
                .SetApartmentId(1)
                .SetName("TEST_COOKER")
                .SetStatus("TEST")
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.Status == contextModelTest.Status);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<StockContextModel> contextEnumerableBeforeDelete;
            IEnumerable<StockContextModel> contextEnumerableAfterDelete;
            StockContextModel contextModel;

            StockContextSingleton contextSingleton = StockContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.StockId).First();
            contextSingleton.Delete(contextModel.StockId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.StockId.Equals(contextModel.StockId));
        }
    }
}