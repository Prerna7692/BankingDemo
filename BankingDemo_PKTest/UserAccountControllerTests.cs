using BankingDemo_PK.Controllers;
using BankingDemo_PK;
using System.Web.Http.Results;
using BankingDemo_PK.Models;
using Microsoft.AspNetCore.Mvc;
using BankingDemo_PK.Data;
using BankingDemo_PK.Sevices;

namespace BankingDemo_PKTest
{
    [TestClass]
    public class UserAccountControllerTests
    {
        private IUserAccountService _userAccountService;
        private UserAccountController _controller;

        [TestInitialize]
        public void SetUp()
        {
            _userAccountService = new UserAccountService();
            _controller = new UserAccountController(_userAccountService);
        }

        [TestMethod]
        public void GetAllUserAccounts()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(result, Dummydata.UserAccounts);
        }

        [TestMethod]
        public void DeleteUserAccount_ReturnsOk()
        {
            var userId = 5;
            var accountId = 6;
            var result = _controller.Delete(userId, accountId) as OkObjectResult;

            Assert.AreEqual(result?.Value, "Account Deleted");
        }

        [TestMethod]
        public void DeleteNonExistantUserAccount()
        {
            var userId = 15;
            var accountId = 16;
            var result = _controller.Delete(userId, accountId) as OkObjectResult;

            Assert.AreEqual(result?.Value, "No account found with given details.");
        }


    }

}