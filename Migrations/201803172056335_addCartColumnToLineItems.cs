namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCartColumnToLineItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartLineItems", "CartId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartLineItems", "CartId");
            AddForeignKey("dbo.CartLineItems", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartLineItems", "CartId", "dbo.Carts");
            DropIndex("dbo.CartLineItems", new[] { "CartId" });
            DropColumn("dbo.CartLineItems", "CartId");
        }
    }
}
