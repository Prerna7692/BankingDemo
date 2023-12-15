using BankingDemo_PK.Controllers;
using BankingDemo_PK.Data;

namespace BankingDemo_PKTest.ControllerTests
{
    [TestClass]
    public class UserControllerTests
    {
        private UserController _controller;

        [TestInitialize]
        public void SetUp()
        {
            _controller = new UserController();
        }

        [TestMethod]
        public void GetAllUserAccounts()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(result, Dummydata.UserList);
        }
    }

}