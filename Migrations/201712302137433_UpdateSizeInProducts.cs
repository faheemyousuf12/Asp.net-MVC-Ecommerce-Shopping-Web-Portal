namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSizeInProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SizeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SizeId");
            AddForeignKey("dbo.Products", "SizeId", "dbo.Sizes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SizeId", "dbo.Sizes");
            DropIndex("dbo.Products", new[] { "SizeId" });
            DropColumn("dbo.Products", "SizeId");
        }
    }
}
