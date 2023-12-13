using BankingDemo_PK.Controllers;
using BankingDemo_PK;
using System.Web.Http.Results;
using BankingDemo_PK.Models;
using Microsoft.AspNetCore.Mvc;
using BankingDemo_PK.Data;

namespace BankingDemo_PKTest
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