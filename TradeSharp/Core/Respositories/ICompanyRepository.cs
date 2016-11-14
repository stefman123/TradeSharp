using System.Collections.Generic;
using TradeSharp.Core.Models;

namespace TradeSharp.Core.Respositories
{
    public interface ICompanyRepository
    {
        Company GetCompanyById(int id);
        IEnumerable<Company> GetCompanies();
    }
}