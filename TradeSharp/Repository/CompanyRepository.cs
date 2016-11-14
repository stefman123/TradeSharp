using System.Collections.Generic;
using System.Linq;
using TradeSharp.Core.Models;
using TradeSharp.Core.Respositories;
using TradeSharp.Persistence;

namespace TradeSharp.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IApplicationDbContext _context;

        public CompanyRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }
    }
}