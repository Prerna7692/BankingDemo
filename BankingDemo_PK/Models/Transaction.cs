namespace BankingDemo_PK.Models
{
    public class Transaction
    {
        public int accountId { get; set; }
        public int userId { get; set; }
        public int amount { get; set; }
        public TransactionType transactionType { get; set; }
    }
}
