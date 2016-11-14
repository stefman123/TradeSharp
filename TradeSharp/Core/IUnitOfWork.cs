using TradeSharp.Core.Respositories;

namespace TradeSharp.Core
{
    public interface IUnitOfWork
    {
        IInvestmentRepository Investment { get; }
        IBankAccountRepository BankAccount { get; }
        ICompanyRepository Company { get; }
        ITransactionRepository Transaction { get; }

        void Complete();
    }
}