using BankingDemo_PK.Models;

namespace BankingDemo_PK.Sevices
{
    public interface IUserAccountService
    {
        Task<string> Delete(int userId, int accountId);
        List<UserAccount> GetUserAccountsByUserId(int userId);
    }
}
