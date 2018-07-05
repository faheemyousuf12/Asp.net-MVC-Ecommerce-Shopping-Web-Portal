namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReUpdCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropColumn("dbo.Customers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
