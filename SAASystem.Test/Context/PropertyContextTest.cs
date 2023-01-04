using SAASystem.Builder;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test.Context
{
    /// <summary>
    /// PropertyContextTest.cs executes the tests to check if each database function returns view
    public class PropertyContextTest
    {
        [Fact]
        public void SelectAll()
        {
            PropertyContextSingleton contextSingleton = PropertyContextSingleton.Instance;
            IEnumerable<PropertyContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(9, contextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int id = 2;
            PropertyContextSingleton contextSingleton = PropertyContextSingleton.Instance;
            PropertyContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.PropertyId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<PropertyContextModel> contextEnumerable;
            PropertyContextModel contextModelTest;
            PropertyContextModel contextModelLast;
            PropertyBuilder builder = new PropertyBuilder();

            contextModelTest = builder
                .SetAddress("TEMP_ADDRESS")
                .SetCity("TEMP_CITY")
                .SetName("TEMP_NAME")
                .SetPostalCode("TEMP_CODE")
                .SetStreet("TEMP_STREET")
                .Build();

            PropertyContextSingleton contextSingleton = PropertyContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.Last();

            bool isSameObject = contextModelTest.Street.Equals(contextModelLast.Street);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<PropertyContextModel> contextEnumerable;
            PropertyContextModel contextModelLast;
            PropertyContextModel contextModelTest;

            PropertyBuilder builder = new PropertyBuilder();

            PropertyContextSingleton contextSingleton = PropertyContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.PropertyId).First();


            contextModelTest = builder
                .SetPropertyId(contextModelLast.PropertyId)
                .SetAddress("TEMP_ADDRESS")
                .SetCity("TEMP_CITY")
                .SetName("TEMP_NAME")
                .SetPostalCode("TEMP_CODE")
                .SetStreet("TEMP_STREET_UPDATED")
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.Street == contextModelTest.Street);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<PropertyContextModel> contextEnumerableBeforeDelete;
            IEnumerable<PropertyContextModel> contextEnumerableAfterDelete;
            PropertyContextModel contextModel;

            PropertyContextSingleton contextSingleton = PropertyContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.PropertyId).First();
            contextSingleton.Delete(contextModel.PropertyId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.PropertyId.Equals(contextModel.PropertyId));
        }
    }
}