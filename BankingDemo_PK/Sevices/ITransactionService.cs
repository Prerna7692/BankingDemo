using BankingDemo_PK.Models;

namespace BankingDemo_PK.Sevices
{
    public interface ITransactionService
    {
         Task<TransactionResult> Deposit(Transaction transaction);
         Task<TransactionResult> Withdraw(Transaction transaction);

    }
}
