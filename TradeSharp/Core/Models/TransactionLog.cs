namespace TradeSharp.Core.Models
{
    public abstract class TransactionLog
    {
        public Transaction LogTransaction(TransactionType type, ITransaction transactionLog)
        {
            var transaction = CreateTransaction(type);

            transaction.AddTransaction(transactionLog, type);

            return transaction;
        }

        protected abstract Transaction CreateTransaction(TransactionType type);
    }
}