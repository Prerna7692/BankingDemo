using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using BankingDemo_PK.Sevices;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Transactions;

namespace BankingDemo_PK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService userAccountService;

        public UserAccountController(IUserAccountService _userAccountService)
        {
            this.userAccountService = _userAccountService;
        }

        /// <summary>
        /// Fetch all available user accounts (currently fetching from dummy data file)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserAccount> GetAll()
        {
            return Dummydata.UserAccounts; 
        }

        /// <summary>
        /// Fetch available user accounts by userId (currently fetching from dummy data file)
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<UserAccount>>> GetById(int userId)
        {
            //If Id is less than 0 or 0 its an invalid userId
            if (userId <= 0)
            {
                return BadRequest();
            }

            //Get list of accounts, as one user can have multiple accounts
            var result = userAccountService.GetUserAccountsByUserId(userId);
            if (result != null)
            {
                return Ok(result);
            }

            //if no accounts are returned return  message.
            return BadRequest("No account found with given details.");
        }

        /// <summary>
        /// Delete Account on userId and AccountId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int userId, int accountId)
        {
            //check for valid user Id and account Id
            if (userId <= 0 || accountId <= 0)
            {
                return BadRequest();
            }

            //call delete method 
            var result = await userAccountService.Delete(userId, accountId);
            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            //If no account is deleted.
            return BadRequest("No account found with given details.");
        }
    }


}