using System.Collections.Generic;
using TradeSharp.Core.Models;
using TradeSharp.Core.ViewModels;

namespace TradeSharp.Core.Respositories
{
    public interface IInvestmentRepository
    {
        Investment GetInvestment(InvestmentViewModel investment);
        Company GetCompany(InvestmentViewModel investment);
        void RemoveInvestment(Investment investment);
        void AddInvestment(Investment investment);
        Investment GetInvestmentByCompanyId(int companyId, string userId);
        decimal SumInvestments(BankAccount bankAccount);
        decimal SumInvestments(IEnumerable<Investment> investments);
    }
}