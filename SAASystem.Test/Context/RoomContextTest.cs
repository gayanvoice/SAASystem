using SAASystem.Builder;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test.Context
{
    /// <summary>
    /// RoleContextTest.cs executes the tests to check if each database function returns view
    public class RoomContextTest
    {
        [Fact]
        public void SelectAll()
        {
            RoomContextSingleton contextSingleton = RoomContextSingleton.Instance;
            IEnumerable<RoomContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(7, contextEnumerable.Count());
        }
        [Fact]
        public void Select()
        {
            int id = 3;
            RoomContextSingleton contextSingleton = RoomContextSingleton.Instance;
            RoomContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.RoomId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<RoomContextModel> contextEnumerable;
            RoomContextModel contextModelTest;
            RoomContextModel contextModelLast;
            RoomBuilder builder = new RoomBuilder();

            contextModelTest = builder
                .SetApartmentId(1)
                .SetStatus("TEST")
                .Build();

            RoomContextSingleton contextSingleton = RoomContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.Last();

            bool isSameObject = contextModelTest.Status.Equals(contextModelLast.Status);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<RoomContextModel> contextEnumerable;
            RoomContextModel contextModelLast;
            RoomContextModel contextModelTest;

            RoomBuilder builder = new RoomBuilder();

            RoomContextSingleton contextSingleton = RoomContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.RoomId).First();


            contextModelTest = builder
                .SetRoomId(contextModelLast.RoomId)
                .SetApartmentId(1)
                .SetStatus("UPDATED")
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.Status == contextModelTest.Status);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<RoomContextModel> contextEnumerableBeforeDelete;
            IEnumerable<RoomContextModel> contextEnumerableAfterDelete;
            RoomContextModel contextModel;

            RoomContextSingleton contextSingleton = RoomContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.RoomId).First();
            contextSingleton.Delete(contextModel.RoomId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.RoomId.Equals(contextModel.RoomId));
        }
    }
}