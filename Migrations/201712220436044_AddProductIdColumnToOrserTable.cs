namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductIdColumnToOrserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropColumn("dbo.Orders", "ProductId");
        }
    }
}
