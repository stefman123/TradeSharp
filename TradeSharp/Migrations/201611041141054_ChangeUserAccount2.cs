using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class ChangeUserAccount2 : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.UserAccounts", "BankAccounts");
            RenameColumn("dbo.Investments", "UserAccount_Id", "BankAccount_Id");
            RenameIndex("dbo.Investments", "IX_UserAccount_Id", "IX_BankAccount_Id");
        }

        public override void Down()
        {
            RenameIndex("dbo.Investments", "IX_BankAccount_Id", "IX_UserAccount_Id");
            RenameColumn("dbo.Investments", "BankAccount_Id", "UserAccount_Id");
            RenameTable("dbo.BankAccounts", "UserAccounts");
        }
    }
}