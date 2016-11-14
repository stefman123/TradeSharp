using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TradeSharp.Core.Models;

namespace TradeSharp.Persistence
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Investment> Investments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<UserAccount>()
            //        .HasMany(u => u.Investments)
            //        .WithMany(u => u.)

            //modelBuilder.Entity<ApplicationUser>()
            //.HasOptional(f => f.BankAccount)
            //.WithRequired(s => s.User);

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasRequired(u => u.BankAccount);
            //.WithMany(u => u.BankAccount)
            //.WillCascadeOnDelete(false);
            //.WithMany( u => u.UserBankAccount)
            //.HasRequired(f => f.UserBankAccount);


            //    //modelBuilder.Entity<UserAccount>()
            //    //    .HasMany(f => f.Investments)
            //    //    .WithRequired(f => f.Account);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(m => m.BankAccount)
                .WithRequired(m => m.User)
                .Map(p => p.MapKey("UserId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}