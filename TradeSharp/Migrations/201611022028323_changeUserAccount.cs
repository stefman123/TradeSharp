using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class changeUserAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Investments",
                    c => new
                    {
                        Id = c.Int(false, true),
                        AccountId = c.String(),
                        CompanyId = c.String(),
                        ShareQuantity = c.Int(false),
                        Amount = c.Decimal(false, 18, 2),
                        Account_Id = c.Int(),
                        Company_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.Account_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Company_Id);

            CreateTable(
                    "dbo.CompanyViewModals",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Quantity = c.Int(false),
                        Price = c.Decimal(false, 18, 2)
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Investments", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Investments", "Account_Id", "dbo.UserAccounts");
            DropIndex("dbo.Investments", new[] {"Company_Id"});
            DropIndex("dbo.Investments", new[] {"Account_Id"});
            DropTable("dbo.CompanyViewModals");
            DropTable("dbo.Investments");
        }
    }
}