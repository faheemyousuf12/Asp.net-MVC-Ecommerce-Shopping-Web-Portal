namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserBasketId", "dbo.UserBaskets");
            DropIndex("dbo.Orders", new[] { "UserBasketId" });
            DropColumn("dbo.Orders", "UserBasketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserBasketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "UserBasketId");
            AddForeignKey("dbo.Orders", "UserBasketId", "dbo.UserBaskets", "Id", cascadeDelete: true);
        }
    }
}
