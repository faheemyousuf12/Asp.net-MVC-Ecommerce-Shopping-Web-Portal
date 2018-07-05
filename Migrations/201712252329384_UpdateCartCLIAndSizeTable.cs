namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartCLIAndSizeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CartLineItems", "SizeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartLineItems", "SizeId");
            AddForeignKey("dbo.CartLineItems", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
            DropColumn("dbo.CartLineItems", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartLineItems", "Size", c => c.String());
            DropForeignKey("dbo.CartLineItems", "SizeId", "dbo.Sizes");
            DropIndex("dbo.CartLineItems", new[] { "SizeId" });
            DropColumn("dbo.CartLineItems", "SizeId");
            DropTable("dbo.Sizes");
        }
    }
}
