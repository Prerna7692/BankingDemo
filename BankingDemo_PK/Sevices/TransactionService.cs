using BankingDemo_PK.Data;
using BankingDemo_PK.Models;

namespace BankingDemo_PK.Sevices
{
    public class TransactionService : ITransactionService
    {
        /// <summary>
        /// Deposit transaction details
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<TransactionResult> Deposit(Transaction transaction)
        {
            TransactionResult result = new TransactionResult();
            try
            {
                //Fetch existing account to validate the transaction.
                var existingDetails = Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId);
                
                //Validate transaction
                if (existingDetails == null)
                {
                    result.message = "no account found.";
                }
                else if (transaction == null)
                {
                    result.message = "No transaction data found.";
                }
                else if (transaction.amount <= 0)
                {
                    result.message = "Please enter valid amount.";
                }
                else if (transaction.amount > 10000)
                {
                    result.message = "Please enter valid amount. Cannot deposit amount above 10,000";
                }
                //Add transaction to transactions and Update the available balance in the UserAccount.
                else
                {
                    Dummydata.Transactions.Add(transaction);

                    //Add amount to available balance.
                    Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId).availableBalance = transaction.amount + existingDetails.availableBalance;

                    var updatedDetails = Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId);
                    result.message = "Deposit successful! Your Available balance is : $" + updatedDetails?.availableBalance;
                    result.availableBalance = updatedDetails?.availableBalance;
                }

                return result;
            }
            catch (Exception exception)
            {
                result.message = exception.Message;
                return result;
            }
        }

        public async Task<TransactionResult> Withdraw(Transaction transaction)
        {
            TransactionResult result = new TransactionResult();
            try
            {
                //Fetch existing account to validate the transaction.
                var existingDetails = Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId);
                if (existingDetails == null)
                {
                    result.message = "no account found.";
                }
                // Validate the request
                else if (transaction == null)
                {
                    result.message = "no transaction data found.";
                }
                else if (transaction.amount <= 0)
                {
                    result.message = "Please enter valid amount.";
                }
                else if (transaction.amount > existingDetails.availableBalance * (0.9))
                {
                    result.message = "Please enter valid amount. Cannot withdraw amount above 90% of current balance";
                }
                //Add transactio to transactions and Update the available balance in the UserAccount.
                else
                {
                    Dummydata.Transactions.Add(transaction);

                    //deduct amount to available balance.
                    Dummydata.UserAccounts.FirstOrDefault(x => x.userId == transaction.userId && x.accountId == transaction.accountId).availableBalance = existingDetails.availableBalance - transaction.amount;

                    var updatedDetails = Dummydata.UserAccounts.Single(x => x.userId == transaction.userId && x.accountId == transaction.accountId);
                    result.message = "Withdrawal successful! Your Available balance is : $" + updatedDetails.availableBalance;
                    result.availableBalance = updatedDetails.availableBalance;
                }
                return result;
            }
            catch (Exception exception)
            {
                result.message = exception.Message;
                return result;
            }
        }
    }

    public class TransactionResult
    {
        public string message { get; set;}
        public int? availableBalance { get; set;}
    }
}
