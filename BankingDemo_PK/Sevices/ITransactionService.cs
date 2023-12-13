using BankingDemo_PK.Models;

namespace BankingDemo_PK.Sevices
{
    public interface ITransactionService
    {
        string Deposit(Transaction transaction);
        string Withdraw(Transaction transaction);

    }
}
