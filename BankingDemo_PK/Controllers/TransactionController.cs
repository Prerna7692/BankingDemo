using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using BankingDemo_PK.Sevices;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;

namespace BankingDemo_PK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService _transactionService)
        {
            this.transactionService = _transactionService;
        }

        [HttpGet]
        public IEnumerable<Transaction> GetAll()
        {
            return Dummydata.Transactions;
        }

        [HttpPost("deposit")]
        public IActionResult Deposit(Transaction transaction)
        {
            try
            {
                var result = transactionService.Deposit(transaction);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(Transaction transaction)
        {
            try
            {
                var result = transactionService.Withdraw(transaction);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }


}