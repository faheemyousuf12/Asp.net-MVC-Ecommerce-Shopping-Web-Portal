namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartLi1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartLineItems", "cartId", "dbo.Carts");
            DropIndex("dbo.CartLineItems", new[] { "cartId" });
            DropColumn("dbo.CartLineItems", "cartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartLineItems", "cartId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartLineItems", "cartId");
            AddForeignKey("dbo.CartLineItems", "cartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
