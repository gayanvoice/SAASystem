using SAASystem.Builder;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test.Context
{
    /// <summary>
    /// ApartmentContextTest.cs executes the tests to check if each database function returns view
    public class ApartmentContextTest
    {
        [Fact]
        public void Select()
        {
            int apartmentId = 1;
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel apartmentContextModelTest = builder
                 .SetApartmentId(apartmentId)
                 .SetPropertyId(2)
                 .SetSuiteId(2)
                 .SetCode("AC-PES-1")
                 .Build(); 
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentContextModel apartmentContextModel = apartmentContextSingleton.Select(apartmentId);
            Assert.True(apartmentContextModelTest.ApartmentId.Equals(apartmentContextModel.ApartmentId));
        }
        [Fact]
        public void SelectAll()
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            IEnumerable<ApartmentContextModel> apartmentContextEnumerable = apartmentContextSingleton.SelectAll();
            Assert.Equal(29, apartmentContextEnumerable.Count());
        }
        [Fact]
        public void Insert()
        {
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel apartmentContextModelTemp = builder
                 .SetPropertyId(2)
                 .SetSuiteId(2)
                 .SetCode("TEMP")
                 .Build();
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            apartmentContextSingleton.Insert(apartmentContextModelTemp);
            IEnumerable<ApartmentContextModel> apartmentContextEnumerable = apartmentContextSingleton.SelectAll();
            ApartmentContextModel apartmentContextModelLast = apartmentContextEnumerable.Last();
            bool isSameObject = apartmentContextModelTemp.Code.Equals(apartmentContextModelLast.Code);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            IEnumerable<ApartmentContextModel> apartmentContextEnumerable = apartmentContextSingleton.SelectAll();
            ApartmentContextModel apartmentContextModel = apartmentContextEnumerable.OrderByDescending(a => a.ApartmentId).First();
            ApartmentBuilder builder = new ApartmentBuilder();
            ApartmentContextModel apartmentContextModelUpdate = builder
                 .SetApartmentId(apartmentContextModel.ApartmentId)
                 .SetPropertyId(apartmentContextModel.PropertyId)
                 .SetSuiteId(apartmentContextModel.SuiteId)
                 .SetCode("TEMP_2")
                 .Build();
            apartmentContextSingleton.Update(apartmentContextModelUpdate);
            apartmentContextEnumerable = apartmentContextSingleton.SelectAll();
            Assert.Contains(apartmentContextEnumerable, a => a.Code == apartmentContextModelUpdate.Code);
        }
        [Fact]
        public void Delete()
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            IEnumerable<ApartmentContextModel> apartmentContextEnumerableBeforeDelete = apartmentContextSingleton.SelectAll();
            ApartmentContextModel apartmentContextModel = apartmentContextEnumerableBeforeDelete.OrderByDescending(a => a.ApartmentId).First();
            apartmentContextSingleton.Delete(apartmentContextModel.ApartmentId);
            IEnumerable<ApartmentContextModel> apartmentContextEnumerableAfterDelete = apartmentContextSingleton.SelectAll();
            Assert.DoesNotContain(apartmentContextEnumerableAfterDelete, a => a.ApartmentId.Equals(apartmentContextModel.ApartmentId));
        }
    }
}