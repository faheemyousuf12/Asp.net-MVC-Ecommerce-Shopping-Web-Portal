namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lineitemstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineItems", "productId", "dbo.Products");
            DropIndex("dbo.LineItems", new[] { "productId" });
            DropTable("dbo.LineItems");
        }
    }
}
