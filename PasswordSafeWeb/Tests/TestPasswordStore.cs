using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordSafeWeb.Database;

namespace PasswordSafeWeb.Tests
{
    [TestClass]
    public class TestPasswordStore
    {
        [TestMethod]
        public void TestSave()
        {
            var userInfos = PasswordStore.Instance.GetAll();
            Assert.IsNotNull(userInfos);

            var userInfo = new UserInfo
            {
                Id = -1,
                Username = "TestUser",
                Description = "For testing purposes",
                Email = "testuser@test.com",
                LoginUrl = "https://www.test.com",
                PassPhrase = "testing123!"
            };

            var newUserId = PasswordStore.Instance.Create(userInfo);
            Assert.AreNotEqual(newUserId, -1);

            var createdUser = PasswordStore.Instance.Get(newUserId);
            Assert.IsNotNull(createdUser);
        }

        [TestMethod]
        public void TestLoad()
        {

        }
    }
}