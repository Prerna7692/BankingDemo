using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using System.Web.Http;

namespace BankingDemo_PK.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return Dummydata.UserList; 
        }
    }


}