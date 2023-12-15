using BankingDemo_PK;
using BankingDemo_PK.Models;
using BankingDemo_PK.Sevices;

namespace BankingDemo_PKTest.ServiceTests
{
    [TestClass]
    public class TransactionServiceTests
    {
        private ITransactionService _transactionService;

        [TestInitialize]
        public void SetUp()
        {
            _transactionService = new TransactionService();
        }

        [TestMethod]
        public async void Deposit_WithValidTransaction_ReturnsOk()
        {
            //Arrange
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 100, transactionType = TransactionType.Deposit };
            
            //Act
            var result = await _transactionService.Deposit(transaction);

            //Assert
            Assert.AreEqual(result.message, "Deposit successful! Your Available balance is : $1100");
            Assert.AreEqual(result.availableBalance, 1100);
        }

        [TestMethod]
        public async void Deposit_WithAmountGreaterThanValue()
        {
            //Arrange
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 20000, transactionType = TransactionType.Deposit };
            
            //Act
            var result = await _transactionService.Deposit(transaction);

            //Assert
            Assert.AreEqual(result.message, "Please enter valid amount. Cannot deposit amount above 10,000");
        }

        [TestMethod]
        public async void Deposit_WithAmountAsZero()
        {
            //Arrange
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 0, transactionType = TransactionType.Deposit };
            
            //Act
            var result = await _transactionService.Deposit(transaction);

            //Assert
            Assert.AreEqual(result.message, "Please enter valid amount.");
        }

        [TestMethod]
        public async void Deposit_WithInvalidAccount()
        {
            //arrange
            var transaction = new Transaction() { userId = 7, accountId = 10, amount = 100, transactionType = TransactionType.Deposit };
            
            //Act
            var result = await _transactionService.Deposit(transaction);

            //Assert
            Assert.AreEqual(result.message, "no account found.");
        }

        [TestMethod]
        public async void Withdraw_WithAmountGreaterThan90Percent()
        {
            //arrange
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 20000, transactionType = TransactionType.Withdraw };
            
            //Act
            var result = await _transactionService.Withdraw(transaction);

            //Assert
            Assert.AreEqual(result?.message, "Please enter valid amount. Cannot withdraw amount above 90% of current balance");
        }

        [TestMethod]
        public async void Withdraw_WithAmountAsZero()
        {
            //arrange
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 0, transactionType = TransactionType.Withdraw };

            //Act
            var result = await _transactionService.Withdraw(transaction);

            //Assert
            Assert.AreEqual(result.message, "Please enter valid amount.");
        }

        [TestMethod]
        public async void Withdraw_WithInvalidAccount()
        {
            //arrange
            var transaction = new Transaction() { userId = 7, accountId = 10, amount = 100, transactionType = TransactionType.Withdraw };
            
            //Act
            var result = await _transactionService.Withdraw(transaction);

            //Assert
            Assert.AreEqual(result.message, "no account found.");
        }
    }

}