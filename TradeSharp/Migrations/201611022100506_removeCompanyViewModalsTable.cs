using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class removeCompanyViewModalsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CompanyViewModals");
        }

        public override void Down()
        {
            CreateTable(
                    "dbo.CompanyViewModals",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Quantity = c.Int(false),
                        Price = c.Decimal(false, 18, 2),
                        CurrentShareQuantity = c.Int(false)
                    })
                .PrimaryKey(t => t.Id);
        }
    }
}