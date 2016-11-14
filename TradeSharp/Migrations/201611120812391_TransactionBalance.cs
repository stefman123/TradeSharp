using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class TransactionBalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Balance", c => c.Decimal(false, 18, 2));
        }

        public override void Down()
        {
            DropColumn("dbo.Transactions", "Balance");
        }
    }
}