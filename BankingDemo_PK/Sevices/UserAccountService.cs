using BankingDemo_PK.Data;
using BankingDemo_PK.Models;
using System.Linq;

namespace BankingDemo_PK.Sevices
{
    public class UserAccountService : IUserAccountService
    {
        /// <summary>
        /// Delete account on userId and accountId match
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<string> Delete(int userId, int accountId)
        {
            var userAccount = Dummydata.UserAccounts.Where(x => x.userId == userId && x.accountId == accountId).FirstOrDefault();
            if (userAccount != null)
            {
                Dummydata.UserAccounts.Remove(userAccount);
                return "Account Deleted";
            }

            return null;
        }

        /// <summary>
        /// Fetch all accounts on userID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserAccount> GetUserAccountsByUserId(int userId)
        {
            var userAccounts = Dummydata.UserAccounts.Where(x => x.userId == userId).ToList();
            return userAccounts;
        }
    }
}
