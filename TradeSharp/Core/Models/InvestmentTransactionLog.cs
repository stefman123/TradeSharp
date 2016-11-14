namespace TradeSharp.Core.Models
{
    public class InvestmentTransactionLog : TransactionLog
    {
        protected override Transaction CreateTransaction(TransactionType type)
        {
            Transaction transaction = null;

            transaction = new InvestmentTransaction();

            return transaction;
        }
    }
}