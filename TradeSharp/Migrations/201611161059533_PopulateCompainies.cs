namespace TradeSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCompainies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO COMPANIES (Name) VALUES (	'Acme A')");
            Sql("INSERT INTO COMPANIES (Name) VALUES (	'Acme B')");
            Sql("INSERT INTO COMPANIES (Name) VALUES (	'Acme C')");
            Sql("INSERT INTO COMPANIES (Name) VALUES (	'Acme D')");
            Sql("INSERT INTO COMPANIES (Name) VALUES (	'Acme E')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM COMPANIES WHERE Id IN (1,2,3,4,5");
        }
    }
}
