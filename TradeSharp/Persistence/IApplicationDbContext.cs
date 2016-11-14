using System.Data.Entity;
using TradeSharp.Core.Models;

namespace TradeSharp.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<BankAccount> BankAccounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Investment> Investments { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
    }
}