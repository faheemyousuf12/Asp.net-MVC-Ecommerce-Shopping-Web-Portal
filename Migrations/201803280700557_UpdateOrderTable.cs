namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserBasketId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CartLineItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CartLineItemId");
            CreateIndex("dbo.Orders", "UserBasketId");
            AddForeignKey("dbo.Orders", "CartLineItemId", "dbo.CartLineItems", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "UserBasketId", "dbo.UserBaskets", "Id", cascadeDelete: false);
            DropColumn("dbo.Orders", "TotalQty");
            DropColumn("dbo.Orders", "TotalAmount");
            DropColumn("dbo.Orders", "DeliveryCharges");
            DropColumn("dbo.Orders", "GrandTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "GrandTotal", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "DeliveryCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TotalAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TotalQty", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "UserBasketId", "dbo.UserBaskets");
            DropForeignKey("dbo.Orders", "CartLineItemId", "dbo.CartLineItems");
            DropIndex("dbo.Orders", new[] { "UserBasketId" });
            DropIndex("dbo.Orders", new[] { "CartLineItemId" });
            DropColumn("dbo.Orders", "CartLineItemId");
            DropColumn("dbo.Orders", "UserBasketId");
        }
    }
}
