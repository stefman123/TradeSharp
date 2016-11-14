using TradeSharp.Core.Models;

namespace TradeSharp.Core.Respositories
{
    public interface IBankAccountRepository
    {
        BankAccount GetBankAccountById(int accountId);
        BankAccount GetBankAccountByUserId(string userId);
        BankAccount GetBankAccountInvestmentsByUserId(string userId);
        void AddNewBankAccount(BankAccount userAccount);
    }
}