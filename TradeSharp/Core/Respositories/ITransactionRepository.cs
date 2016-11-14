using TradeSharp.Core.Models;

namespace TradeSharp.Core.Respositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        void RemoveTransaction(Transaction transaction);
    }
}