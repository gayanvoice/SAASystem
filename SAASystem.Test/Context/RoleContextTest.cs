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
    /// RoleContextTest.cs executes the tests to check if each database function returns view
    public class RoleContextTest
    {
        [Fact]
        public void SelectAll()
        {
            RoleContextSingleton contextSingleton = RoleContextSingleton.Instance;
            IEnumerable<RoleContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(2, contextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int id = 1;
            RoleContextSingleton contextSingleton = RoleContextSingleton.Instance;
            RoleContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.RoleId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<RoleContextModel> contextEnumerable;
            RoleContextModel contextModelTest;
            RoleContextModel contextModelLast;
            RoleBuilder builder = new RoleBuilder();

            contextModelTest = builder
               .SetName("TEMP_NAME")
               .SetStatus(RoleStatusEnum.ENABLE.ToString())
               .Build();

            RoleContextSingleton contextSingleton = RoleContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.Last();

            bool isSameObject = contextModelTest.Name.Equals(contextModelLast.Name);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<RoleContextModel> contextEnumerable;
            RoleContextModel contextModelLast;
            RoleContextModel contextModelTest;

            RoleBuilder builder = new RoleBuilder();

            RoleContextSingleton contextSingleton = RoleContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.RoleId).First();


            contextModelTest = builder
                .SetRoleId(contextModelLast.RoleId)
                .SetName("TEMP_UPDATE")
                .SetStatus(RoleStatusEnum.ENABLE.ToString())
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.Name == contextModelTest.Name);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<RoleContextModel> contextEnumerableBeforeDelete;
            IEnumerable<RoleContextModel> contextEnumerableAfterDelete;
            RoleContextModel contextModel;

            RoleContextSingleton contextSingleton = RoleContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.RoleId).First();
            contextSingleton.Delete(contextModel.RoleId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.RoleId.Equals(contextModel.RoleId));
        }
    }
}