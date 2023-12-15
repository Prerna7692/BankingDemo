using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using System.Web.Http;

namespace BankingDemo_PK.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// Fetch all available users (currently fetching from dummy data file)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return Dummydata.UserList; 
        }
    }


}