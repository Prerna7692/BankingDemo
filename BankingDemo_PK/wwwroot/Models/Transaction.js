 class Transaction {
    constructor(userId, accountId, amount, transactionType) {
        this.accountId = accountId;
        this.userId = userId;
        this.amount = amount;
        this.transactionType = transactionType;
    }
}