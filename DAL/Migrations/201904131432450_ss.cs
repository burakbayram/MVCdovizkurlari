namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrenyCode = c.String(),
                        CurrencyName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Unit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExchangeRateDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrossOrder = c.Int(nullable: false),
                        CurrencyCode = c.String(),
                        CurrencyName = c.String(),
                        Buying = c.Double(nullable: false),
                        Selling = c.Double(nullable: false),
                        Currency_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id, cascadeDelete: true)
                .Index(t => t.Currency_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExchangeRateDatas", "Currency_Id", "dbo.Currencies");
            DropIndex("dbo.ExchangeRateDatas", new[] { "Currency_Id" });
            DropTable("dbo.ExchangeRateDatas");
            DropTable("dbo.Currencies");
        }
    }
}
