using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class ChangeToInvestmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "SharePrice", c => c.Decimal(false, 18, 2));
        }

        public override void Down()
        {
            DropColumn("dbo.Investments", "SharePrice");
        }
    }
}