using BankingDemo_PK.Models;

namespace BankingDemo_PK.Data
{
    public static class Dummydata
    {
        public static List<User> UserList = new List<User>();
        public static List<UserAccount> UserAccounts = new List<UserAccount>();
        public static List<Transaction> Transactions = new List<Transaction>();

        static Dummydata()
        {
            UserList.Add(new User() { userId = 1, userName = "Prerna" });
            UserList.Add(new User() { userId = 2, userName = "Prerna_01" });
            UserList.Add(new User() { userId = 3, userName = "Prerna_02" });
            UserList.Add(new User() { userId = 4, userName = "Prerna_03" });
            UserList.Add(new User() { userId = 5, userName = "Prerna_04" });

            UserAccounts.Add(new UserAccount() { userId = 1, accountId = 1, availableBalance = 1000 });
            UserAccounts.Add(new UserAccount() { userId = 1, accountId = 2, availableBalance = 2000 });
            UserAccounts.Add(new UserAccount() { userId = 2, accountId = 3, availableBalance = 200  });
            UserAccounts.Add(new UserAccount() { userId = 3, accountId = 4, availableBalance = 100  });
            UserAccounts.Add(new UserAccount() { userId = 4, accountId = 5, availableBalance = 100  });
            UserAccounts.Add(new UserAccount() { userId = 5, accountId = 6, availableBalance = 100 });

            Transactions.Add(new Transaction() { userId = 1, accountId = 1, amount = 100, transactionType = TransactionType.Deposit });
            Transactions.Add(new Transaction() { userId = 1, accountId = 2 , amount = 100 , transactionType = TransactionType.Deposit });
            Transactions.Add(new Transaction() { userId = 2, accountId = 3 , amount = 100 , transactionType = TransactionType.Deposit });
            Transactions.Add(new Transaction() { userId = 3, accountId = 4 , amount = 100 , transactionType = TransactionType.Withdraw});
            Transactions.Add(new Transaction() { userId = 4, accountId = 5 , amount = 100 , transactionType = TransactionType.Withdraw});
        }
    }
}
