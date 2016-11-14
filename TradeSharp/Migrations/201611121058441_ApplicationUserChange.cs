using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class ApplicationUserChange : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BankAccounts", new[] {"UserId"});
            AlterColumn("dbo.BankAccounts", "UserId", c => c.String(false, 128));
            CreateIndex("dbo.BankAccounts", "UserId");
        }

        public override void Down()
        {
            DropIndex("dbo.BankAccounts", new[] {"UserId"});
            AlterColumn("dbo.BankAccounts", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BankAccounts", "UserId");
        }
    }
}