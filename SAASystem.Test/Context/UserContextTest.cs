using SAASystem.Builder;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SAASystem.Test.Context
{
    /// <summary>
    /// UserContextTest.cs executes the tests to check if each database function returns view
    public class UserContextTest
    {
        [Fact]
        public void SelectAll()
        {
            UserContextSingleton contextSingleton = UserContextSingleton.Instance;
            IEnumerable<UserContextModel> contextEnumerable = contextSingleton.SelectAll();
            Assert.Equal(9, contextEnumerable.Count());
        }
        [Fact]
        public void SelectUserId()
        {
            string username = "emily";
            UserContextSingleton contextSingleton = UserContextSingleton.Instance;
            UserContextModel contextModel = contextSingleton.Select(username);
            Assert.True(contextModel.Username.Equals(username));
        }
        [Fact]
        public void SelectUserName()
        {
            int id = 1;
            UserContextSingleton contextSingleton = UserContextSingleton.Instance;
            UserContextModel contextModel = contextSingleton.Select(id);
            Assert.True(contextModel.UserId.Equals(id));
        }
        [Fact]
        public void Insert()
        {
            IEnumerable<UserContextModel> contextEnumerable;
            UserContextModel contextModelTest;
            UserContextModel contextModelLast;
            UserBuilder builder = new UserBuilder();

            contextModelTest = builder
                .SetUsername("TEMP")
                .SetPassword("1234")
                .SetEmail("temp@temp.com")
                .SetPhoneNo("0740006")
                .SetSurname("TEMP_SURNAME")
                .SetGivenName("TEMP_GIVENAME")
                .SetAddress("TEMP_ADDRESS")
                .Build();

            UserContextSingleton contextSingleton = UserContextSingleton.Instance;
            contextSingleton.Insert(contextModelTest);

            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.UserId).First(); ;

            bool isSameObject = contextModelTest.Username.Equals(contextModelLast.Username);
            Assert.True(isSameObject);
        }
        [Fact]
        public void Update()
        {
            IEnumerable<UserContextModel> contextEnumerable;
            UserContextModel contextModelLast;
            UserContextModel contextModelTest;

            UserBuilder builder = new UserBuilder();

            UserContextSingleton contextSingleton = UserContextSingleton.Instance;
            contextEnumerable = contextSingleton.SelectAll();
            contextModelLast = contextEnumerable.OrderByDescending(a => a.UserId).First();


            contextModelTest = builder
                .SetUserId(contextModelLast.UserId)
                .SetUsername("UPDATE")
                .SetPassword("1234")
                .SetEmail("temp@temp.com")
                .SetPhoneNo("0740006")
                .SetSurname("TEMP_SURNAME")
                .SetGivenName("TEMP_GIVENAME")
                .SetAddress("TEMP_ADDRESS")
                .Build();

            contextSingleton.Update(contextModelTest);
            contextEnumerable = contextSingleton.SelectAll();
            Assert.Contains(contextEnumerable, a => a.Username == contextModelTest.Username);
        }
        [Fact]
        public void Delete()
        {
            IEnumerable<UserContextModel> contextEnumerableBeforeDelete;
            IEnumerable<UserContextModel> contextEnumerableAfterDelete;
            UserContextModel contextModel;

            UserContextSingleton contextSingleton = UserContextSingleton.Instance;

            contextEnumerableBeforeDelete = contextSingleton.SelectAll();

            contextModel = contextEnumerableBeforeDelete.OrderByDescending(a => a.UserId).First();
            contextSingleton.Delete(contextModel.UserId);

            contextEnumerableAfterDelete = contextSingleton.SelectAll();

            Assert.DoesNotContain(contextEnumerableAfterDelete, a => a.UserId.Equals(contextModel.UserId));
        }
    }
}