using BankingDemo_PK;
using BankingDemo_PK.Controllers;
using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using BankingDemo_PK.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace BankingDemo_PKTest.ControllerTests
{
    [TestClass]
    public class TransactionControllerTests
    {
        private TransactionController _controller;
        private ITransactionService _transactionService;

        [TestInitialize]
        public void SetUp()
        {
            _transactionService = new TransactionService();
            _controller = new TransactionController(_transactionService);
        }

        [TestMethod]
        public void GetAllTransactions()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(result, Dummydata.Transactions);
        }

        [TestMethod]
        public async void Deposit_WithValidTransaction_ReturnsOk()
        {
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 100, transactionType = TransactionType.Deposit };
            var result = await _controller.Deposit(transaction) as OkObjectResult;

            Assert.AreEqual(result?.Value, "Deposit successful! Your Available balance is : $1100");
        }

        [TestMethod]
        public async void Deposit_WithAmountGreaterThanValue()
        {
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 20000, transactionType = TransactionType.Deposit };
            var result = await _controller.Deposit(transaction) as OkObjectResult;

            Assert.AreEqual(result?.Value, "Please enter valid amount. Cannot deposit amount above 10,000");
        }

        [TestMethod]
        public async void Deposit_WithAmountAsZero()
        {
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 0, transactionType = TransactionType.Deposit };
            var result = await _controller.Deposit(transaction) as OkObjectResult;

            Assert.AreEqual(result?.Value, "Please enter valid amount.");
        }

        [TestMethod]
        public async void Deposit_WithInvalidAccount()
        {
            var transaction = new Transaction() { userId = 7, accountId = 10, amount = 100, transactionType = TransactionType.Deposit };
            var result = await _controller.Deposit(transaction) as OkObjectResult;

            Assert.AreEqual(result?.Value, "no account found.");
        }

        [TestMethod]
        public async void Withdraw_WithAmountGreaterThan90Percent()
        {
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 20000, transactionType = TransactionType.Withdraw };
            var result = await _controller.Withdraw(transaction) as OkObjectResult;

            Assert.AreEqual(result?.Value, "Please enter valid amount. Cannot withdraw amount above 90% of current balance");
        }

        [TestMethod]
        public async void Withdraw_WithAmountAsZero()
        {
            var transaction = new Transaction() { userId = 1, accountId = 1, amount = 0, transactionType = TransactionType.Withdraw };
            var result = await _controller.Withdraw(transaction) as OkObjectResult;

            Assert.AreEqual(result?.Value, "Please enter valid amount.");
        }

        [TestMethod]
        public async void Withdraw_WithInvalidAccount()
        {
            var transaction = new Transaction() { userId = 7, accountId = 10, amount = 100, transactionType = TransactionType.Withdraw };
            var result = await _controller.Withdraw(transaction) as OkObjectResult;

            Assert.AreEqual(result?.Value, "no account found.");
        }
    }

}