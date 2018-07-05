namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jdsakh1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ChildCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ChildCategoryId");
            AddForeignKey("dbo.Products", "ChildCategoryId", "dbo.ChildCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ChildCategoryId", "dbo.ChildCategories");
            DropIndex("dbo.Products", new[] { "ChildCategoryId" });
            DropColumn("dbo.Products", "ChildCategoryId");
        }
    }
}
