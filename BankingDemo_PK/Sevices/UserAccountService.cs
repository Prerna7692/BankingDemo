using BankingDemo_PK.Data;

namespace BankingDemo_PK.Sevices
{
    public class UserAccountService : IUserAccountService
    {
        public string Delete(int userId, int accountId)
        {
            var userAccount = Dummydata.UserAccounts.Where(x => x.userId == userId && x.accountId == accountId).FirstOrDefault();
            if (userAccount != null)
            {
                Dummydata.UserAccounts.Remove(userAccount);
                return "Account Deleted";
            }

            return "No account found with given details.";
        }
    }
}
