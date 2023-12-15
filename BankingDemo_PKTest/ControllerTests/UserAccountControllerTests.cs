using BankingDemo_PK.Controllers;
using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using BankingDemo_PK.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace BankingDemo_PKTest.ControllerTests
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
            //Act
            List<UserAccount> result = _controller.GetAll();

            //Assert
            Assert.AreEqual(result, Dummydata.UserAccounts);
        }

        [TestMethod]
        public async void GetUserAccountsByUserId_ReturnsOk()
        {
            //Arrange
            var userId = 5;
            var expectedResult = Dummydata.UserAccounts.Where(x => x.userId == userId).Count();

            //Act
            ActionResult<List<UserAccount>> result = await _controller.GetById(userId);

            //Assert
            Assert.AreEqual(result.Value?.Count, expectedResult);
        }

        [TestMethod]
        public async void GetUserAccountsByUserId_ReturnsBadRequest()
        {
            //Arrange
            var userId = 10;

            //Act
            ActionResult<List<UserAccount>> result = _userAccountService.GetUserAccountsByUserId(userId);

            //Assert
            Assert.AreEqual(result.Value?.Count, 0);
        }

        [TestMethod]
        public async void DeleteUserAccount_ReturnsOk()
        {
            //Arrange
            var userId = 5;
            var accountId = 6;

            //Act
            var result = await _controller.Delete(userId, accountId) as OkObjectResult;

            //Assert
            Assert.AreEqual(result?.Value, "Account Deleted");
        }

        [TestMethod]
        public async void DeleteNonExistantUserAccount()
        {
            //arrange
            var userId = 15;
            var accountId = 16;

            //act
            var result = await _controller.Delete(userId, accountId) as OkObjectResult;

            //Assert
            Assert.AreEqual(result?.Value, "No account found with given details.");
        }


    }

}