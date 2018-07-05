namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserBasketTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBaskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.SizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBaskets", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.UserBaskets", "ProductId", "dbo.Products");
            DropForeignKey("dbo.UserBaskets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.UserBaskets", new[] { "SizeId" });
            DropIndex("dbo.UserBaskets", new[] { "ProductId" });
            DropIndex("dbo.UserBaskets", new[] { "CustomerId" });
            DropTable("dbo.UserBaskets");
        }
    }
}
