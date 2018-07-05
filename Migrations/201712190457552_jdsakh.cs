namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jdsakh : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ChildCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ChildCategoryId");
            AddForeignKey("dbo.Products", "ChildCategoryId", "dbo.ChildCategories", "Id", cascadeDelete: true);
        }
    }
}
