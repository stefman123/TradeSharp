using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class Foundation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Accounts",
                    c => new
                    {
                        Id = c.Int(false, true),
                        UserId = c.String(maxLength: 128),
                        Balance = c.Decimal(false, 18, 2)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.Companies",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Transactions",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Type = c.String(),
                        DateTime = c.DateTime(false),
                        Amount = c.Decimal(false, 18, 2),
                        ShareQuantity = c.Int(false),
                        Price = c.Decimal(false, 18, 2),
                        User = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Accounts", new[] {"UserId"});
            DropTable("dbo.Transactions");
            DropTable("dbo.Companies");
            DropTable("dbo.Accounts");
        }
    }
}