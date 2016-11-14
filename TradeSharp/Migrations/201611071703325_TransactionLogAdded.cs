using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class TransactionLogAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Discriminator", c => c.String(false, 128));
        }

        public override void Down()
        {
            DropColumn("dbo.Transactions", "Discriminator");
        }
    }
}