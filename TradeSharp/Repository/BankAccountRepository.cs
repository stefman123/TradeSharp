using System.Data.Entity;
using System.Linq;
using TradeSharp.Core.Models;
using TradeSharp.Core.Respositories;
using TradeSharp.Persistence;

namespace TradeSharp.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly IApplicationDbContext _context;

        public BankAccountRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public BankAccount GetBankAccountById(int accountId)
        {
            return _context.BankAccounts.SingleOrDefault(b => b.Id == accountId);
        }

        public BankAccount GetBankAccountByUserId(string userId)
        {
            return _context.BankAccounts.SingleOrDefault(b => b.User.Id == userId);
        }

        public void AddNewBankAccount(BankAccount userAccount)
        {
            _context.BankAccounts.Add(userAccount);
        }

        public BankAccount GetBankAccountInvestmentsByUserId(string userId)
        {
            return _context.BankAccounts
                .Include(b => b.Investments)
                .Where(b => b.User.Id == userId)
                .SingleOrDefault(b => b.User.Id == userId);
        }
    }
}