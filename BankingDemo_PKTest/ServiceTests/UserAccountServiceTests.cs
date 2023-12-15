using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using BankingDemo_PK.Sevices;

namespace BankingDemo_PKTest.ServiceTests
{
    [TestClass]
    public class UserAccountServiceTests
    {
        private IUserAccountService _userAccountService;

        [TestInitialize]
        public void SetUp()
        {
            _userAccountService = new UserAccountService();
        }

        [TestMethod]
        public async void GetUserAccountsByUserId_ReturnsAccounts()
        {
            //Arrange
            var userId = 5;
            var expectedResult = Dummydata.UserAccounts.Where(x=> x.userId == userId).ToList();

            //Act
            var result = _userAccountService.GetUserAccountsByUserId(userId);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public async void GetUserAccountsByUserId_ReturnsNull()
        {
            //Arrange
            var userId = 10;

            //Act
            var result = _userAccountService.GetUserAccountsByUserId(userId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async void DeleteUserAccount_ReturnsDeletedMessage()
        {
            //Arrange
            var userId = 5;
            var accountId = 6;

            //Act
            var result = await _userAccountService.Delete(userId, accountId);

            //Assert
            Assert.AreEqual(result, "Account Deleted");
        }

        [TestMethod]
        public async void DeleteNonExistantUserAccount()
        {
            //Arrange
            var userId = 15;
            var accountId = 16;

            //Act
            var result = await _userAccountService.Delete(userId, accountId);

            //Assert
            Assert.AreEqual(result, "No account found with given details.");
        }


    }

}