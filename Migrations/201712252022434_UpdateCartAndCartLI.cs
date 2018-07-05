namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartAndCartLI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LineItems", "productId", "dbo.Products");
            DropForeignKey("dbo.Carts", "LineItemId", "dbo.LineItems");
            DropIndex("dbo.LineItems", new[] { "productId" });
            DropIndex("dbo.Carts", new[] { "LineItemId" });
            CreateTable(
                "dbo.CartLineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        cartId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.cartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.cartId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Carts", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "DateTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Carts", "CustomerId");
            AddForeignKey("dbo.Carts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: false);
            DropColumn("dbo.Carts", "LineItemId");
            DropTable("dbo.LineItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Carts", "LineItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CartLineItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartLineItems", "cartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CartLineItems", new[] { "ProductId" });
            DropIndex("dbo.CartLineItems", new[] { "cartId" });
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            DropColumn("dbo.Carts", "DateTime");
            DropColumn("dbo.Carts", "CustomerId");
            DropTable("dbo.CartLineItems");
            CreateIndex("dbo.Carts", "LineItemId");
            CreateIndex("dbo.LineItems", "productId");
            AddForeignKey("dbo.Carts", "LineItemId", "dbo.LineItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LineItems", "productId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
