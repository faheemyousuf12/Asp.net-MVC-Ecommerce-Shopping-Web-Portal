namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignkeyUOMinCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "UomId");
            AddForeignKey("dbo.Products", "UomId", "dbo.UOMs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UomId", "dbo.UOMs");
            DropIndex("dbo.Products", new[] { "UomId" });
            DropColumn("dbo.Products", "UomId");
        }
    }
}
