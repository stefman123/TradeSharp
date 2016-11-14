using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TradeSharp.Core.Models;
using TradeSharp.Core.Respositories;
using TradeSharp.Core.ViewModels;
using TradeSharp.Persistence;

namespace TradeSharp.Repository
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly IApplicationDbContext _context;

        public InvestmentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Investment GetInvestment(InvestmentViewModel investment)
        {
            return _context.Investments
                .Include(i => i.Company)
                .Where(i => i.Company.Id.ToString() == investment.CompanyId)
                .SingleOrDefault(i => i.BankAccount.Id == investment.AccountId);
        }

        public decimal SumInvestments(BankAccount bankAccount)
        {
            return _context.Investments.Where(i => i.BankAccount.User.Id == bankAccount.User.Id)
                       .Sum(i => (decimal?) i.Amount) ?? 0m;
        }

        public decimal SumInvestments(IEnumerable<Investment> investments)
        {
            return investments.Sum(i => (decimal?) i.Amount) ?? 0m;
        }

        public void AddInvestment(Investment investment)
        {
            _context.Investments.Add(investment);
        }

        public Investment GetInvestmentByCompanyId(int companyId, string userId)
        {
            return _context.Investments.SingleOrDefault(i =>
                (i.BankAccount.User.Id == userId) &&
                (i.Company.Id == companyId));
        }


        public Company GetCompany(InvestmentViewModel investment)
        {
            return _context.Companies.SingleOrDefault(c => c.Id.ToString() == investment.CompanyId);
        }


        public void RemoveInvestment(Investment investment)
        {
            _context.Investments.Remove(investment);
        }
    }
}