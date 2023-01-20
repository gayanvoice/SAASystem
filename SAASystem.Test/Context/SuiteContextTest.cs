using SAASystem.Builder;
using SAASystem.Enum;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test.Context
{
    /// <summary>
    /// SuiteContextTest.cs executes the tests to check if each database function returns view
    public class SuiteContextTest
    {
        [Fact]
        public void SelectAll()
        {
            SuiteContextSingleton contextSingleton = SuiteContextSingleton.Instance;
            IEnumerable<SuiteContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(6, contextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int id = 3;
            SuiteContextSingleton contextSingleton = SuiteContextSingleton.Instance;
            SuiteContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.SuiteId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<SuiteContextModel> contextEnumerable;
            SuiteContextModel contextModelTest;
            SuiteContextModel contextModelLast;
            SuiteBuilder builder = new SuiteBuilder();

            contextModelTest = builder
                .SetName("Test")
                .SetCpw(10)
                .SetSize(20)
                .SetSecurityDeposite(100)
                .SetDaysAvailable(297)
                .SetMaximumStay(357)
                .SetStatus(SuiteStatusEnum.ENABLE.ToString())
                .Build();

            SuiteContextSingleton contextSingleton = SuiteContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.Last();

            bool isSameObject = contextModelTest.Name.Equals(contextModelLast.Name);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<SuiteContextModel> contextEnumerable;
            SuiteContextModel contextModelLast;
            SuiteContextModel contextModelTest;

            SuiteBuilder builder = new SuiteBuilder();

            SuiteContextSingleton contextSingleton = SuiteContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.SuiteId).First();


            contextModelTest = builder
                .SetSuiteId(contextModelLast.SuiteId)
                .SetName("Update")
                .SetCpw(10)
                .SetSize(20)
                .SetSecurityDeposite(100)
                .SetDaysAvailable(297)
                .SetMaximumStay(357)
                .SetStatus(SuiteStatusEnum.ENABLE.ToString())
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.Name == contextModelTest.Name);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<SuiteContextModel> contextEnumerableBeforeDelete;
            IEnumerable<SuiteContextModel> contextEnumerableAfterDelete;
            SuiteContextModel contextModel;

            SuiteContextSingleton contextSingleton = SuiteContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.SuiteId).First();
            contextSingleton.Delete(contextModel.SuiteId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.SuiteId.Equals(contextModel.SuiteId));
        }
    }
}