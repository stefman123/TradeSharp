using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class RenameAccountTableToUserAccount : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.Accounts", "UserAccounts");
        }

        public override void Down()
        {
            RenameTable("dbo.UserAccounts", "Accounts");
        }
    }
}