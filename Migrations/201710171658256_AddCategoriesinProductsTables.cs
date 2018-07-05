namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesinProductsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParentCategories", t => t.ParentCategoryId, cascadeDelete: true)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.ParentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GrandCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrandCategories", t => t.GrandCategoryId, cascadeDelete: true)
                .Index(t => t.GrandCategoryId);
            
            CreateTable(
                "dbo.GrandCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildCategories", "ParentCategoryId", "dbo.ParentCategories");
            DropForeignKey("dbo.ParentCategories", "GrandCategoryId", "dbo.GrandCategories");
            DropIndex("dbo.ChildCategories", new[] { "ParentCategoryId" });
            DropIndex("dbo.ParentCategories", new[] { "GrandCategoryId" });
            DropTable("dbo.GrandCategories");
            DropTable("dbo.ParentCategories");
            DropTable("dbo.ChildCategories");
        }
    }
}
