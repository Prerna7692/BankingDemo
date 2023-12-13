using BankingDemo_PK.Data;
using BankingDemo_PK.Models;

namespace BankingDemo_PK.Sevices
{
    public class TransactionService : ITransactionService
    {
        public string Deposit(Transaction transaction)
        {
            try
            {
                var existingDetails = Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId);
                if (existingDetails == null)
                {
                    return "no account found.";
                }

                if (transaction == null)
                {
                    return "no transaction data found.";
                }
                else if (transaction.amount <= 0)
                {
                    return "Please enter valid amount.";
                }
                else if (transaction.amount > 10000)
                {
                    return "Please enter valid amount. Cannot deposit amount above 10,000";
                }

                Dummydata.Transactions.Add(transaction);
                Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId).availableBalance = transaction.amount + existingDetails.availableBalance;

                return "Deposit successful! Your Available balance is : $" + Dummydata.UserAccounts.Single(x => x.userId == transaction.userId && x.accountId == transaction.accountId).availableBalance;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public string Withdraw(Transaction transaction)
        {
            try
            {
                var existingDetails = Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId);
                if (existingDetails == null)
                {
                    return "no account found.";
                }
                // Validate the request
                if (transaction == null)
                {
                    return "no transaction data found.";
                }
                else if (transaction.amount <= 0)
                {
                    return "Please enter valid amount.";
                }
                else if (transaction.amount > existingDetails.availableBalance * (0.9))
                {
                    return "Please enter valid amount. Cannot withdraw amount above 90% of current balance";
                }

                Dummydata.Transactions.Add(transaction);
                Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId).availableBalance = existingDetails.availableBalance - transaction.amount;

                return "Withdrawal successful! Your Available balance is : $" + Dummydata.UserAccounts.Single(x => x.userId == transaction.userId && x.accountId == transaction.accountId).availableBalance;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
