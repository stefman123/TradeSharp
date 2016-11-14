using TradeSharp.Core;
using TradeSharp.Core.Respositories;
using TradeSharp.Repository;

namespace TradeSharp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Investment = new InvestmentRepository(context);
            BankAccount = new BankAccountRepository(context);
            Company = new CompanyRepository(context);
            Transaction = new TransactionRepository(context);
        }

        public IInvestmentRepository Investment { get; set; }
        public IBankAccountRepository BankAccount { get; set; }

        public ICompanyRepository Company { get; set; }

        public ITransactionRepository Transaction { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}