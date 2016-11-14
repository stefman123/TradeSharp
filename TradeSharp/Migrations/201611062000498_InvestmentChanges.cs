using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class InvestmentChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "AccountId", c => c.Int(false));
            AddColumn("dbo.Transactions", "CompanyId", c => c.Int(false));
            AlterColumn("dbo.Transactions", "Type", c => c.Int(false));
            DropColumn("dbo.Transactions", "User");
        }

        public override void Down()
        {
            AddColumn("dbo.Transactions", "User", c => c.String());
            AlterColumn("dbo.Transactions", "Type", c => c.String());
            DropColumn("dbo.Transactions", "CompanyId");
            DropColumn("dbo.Transactions", "AccountId");
        }
    }
}