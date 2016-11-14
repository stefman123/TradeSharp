using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class ChangeInvestmentTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Investments", "UserAccountId");
            DropColumn("dbo.Investments", "CompanyId");
        }

        public override void Down()
        {
            AddColumn("dbo.Investments", "CompanyId", c => c.String());
            AddColumn("dbo.Investments", "UserAccountId", c => c.String());
        }
    }
}