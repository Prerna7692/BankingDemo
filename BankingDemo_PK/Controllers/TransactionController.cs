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

        /// <summary>
        /// Fetch all available transactions (currently fetching from dummy data file)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Transaction> GetAll()
        {
            return Dummydata.Transactions;
        }

        /// <summary>
        /// Deposit transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost("deposit")]
        public async Task<ActionResult> Deposit(Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            var result = await transactionService.Deposit(transaction);
            if (string.IsNullOrEmpty(result.message))
            {
                return Ok(result.availableBalance);
            }

            return BadRequest(result.message);
        }

        /// <summary>
        /// Withdraw transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost("withdraw")]
        public async Task<ActionResult> Withdraw(Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            var result = await transactionService.Withdraw(transaction);
            if (string.IsNullOrEmpty(result.message))
            {
                return Ok(result.availableBalance);
            }

            return BadRequest(result.message);
        }
    }


}