namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guggugug : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "GrandCategoryId", "dbo.GrandCategories");
            DropForeignKey("dbo.ParentCategories", "GrandCategoryId", "dbo.GrandCategories");
            DropIndex("dbo.Products", new[] { "GrandCategoryId" });
            DropIndex("dbo.ParentCategories", new[] { "GrandCategoryId" });
         
            DropColumn("dbo.Products", "GrandCategoryId");
            DropTable("dbo.Invoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrandCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ParentCategories", "GrandCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "GrandCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "ChildCategoryId", "dbo.ChildCategories");
            DropIndex("dbo.Products", new[] { "ChildCategoryId" });
            DropColumn("dbo.Products", "ChildCategoryId");
            CreateIndex("dbo.ParentCategories", "GrandCategoryId");
            CreateIndex("dbo.Products", "GrandCategoryId");
            AddForeignKey("dbo.ParentCategories", "GrandCategoryId", "dbo.GrandCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "GrandCategoryId", "dbo.GrandCategories", "Id", cascadeDelete: true);
        }
    }
}
