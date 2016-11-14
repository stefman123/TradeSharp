using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class CheckChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Investments", "Account_Id", "UserAccount_Id");
            RenameIndex("dbo.Investments", "IX_Account_Id", "IX_UserAccount_Id");
            AddColumn("dbo.Investments", "UserAccountId", c => c.String());
            DropColumn("dbo.Investments", "AccountId");
        }

        public override void Down()
        {
            AddColumn("dbo.Investments", "AccountId", c => c.String());
            DropColumn("dbo.Investments", "UserAccountId");
            RenameIndex("dbo.Investments", "IX_UserAccount_Id", "IX_Account_Id");
            RenameColumn("dbo.Investments", "UserAccount_Id", "Account_Id");
        }
    }
}