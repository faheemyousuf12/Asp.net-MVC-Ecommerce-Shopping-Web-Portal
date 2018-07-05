namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        LineItemId = c.Int(nullable: false),
                        TotalQty = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LineItems", t => t.LineItemId, cascadeDelete: true)
                .Index(t => t.LineItemId);
            
            AddColumn("dbo.LineItems", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.LineItems", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "LineItemId", "dbo.LineItems");
            DropIndex("dbo.Carts", new[] { "LineItemId" });
            DropColumn("dbo.LineItems", "Amount");
            DropColumn("dbo.LineItems", "Qty");
            DropTable("dbo.Carts");
        }
    }
}
