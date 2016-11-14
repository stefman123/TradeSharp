using TradeSharp.Core.Models;
using TradeSharp.Core.Respositories;
using TradeSharp.Persistence;

namespace TradeSharp.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IApplicationDbContext _context;

        public TransactionRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
        }
    }
}