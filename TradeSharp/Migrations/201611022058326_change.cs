using System.Data.Entity.Migrations;

namespace TradeSharp.Migrations
{
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyViewModals", "CurrentShareQuantity", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.CompanyViewModals", "CurrentShareQuantity");
        }
    }
}