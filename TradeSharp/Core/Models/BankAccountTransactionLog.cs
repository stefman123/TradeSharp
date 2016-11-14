namespace TradeSharp.Core.Models
{
    public class BankAccountTransactionLog : TransactionLog
    {
        protected override Transaction CreateTransaction(TransactionType type)
        {
            Transaction transaction = null;

            transaction = new BankAccountTransaction();

            return transaction;
        }
    }
}