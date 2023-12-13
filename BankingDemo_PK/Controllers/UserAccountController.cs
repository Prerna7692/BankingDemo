using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using BankingDemo_PK.Sevices;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IEnumerable<UserAccount> GetAll()
        {
            return Dummydata.UserAccounts; 
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int userId, int accountId)
        {
            try
            {
                var result = userAccountService.Delete(userId, accountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }


}