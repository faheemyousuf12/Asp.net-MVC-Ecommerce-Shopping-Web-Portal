namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerCartMembership : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
            DropColumn("dbo.Carts", "SessionId");
            DropColumn("dbo.Customers", "Username");
            DropColumn("dbo.Customers", "dues");
            DropColumn("dbo.Customers", "Balance");
            DropColumn("dbo.Customers", "ContactNo");
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.Customers", "Image");
            DropColumn("dbo.MembershipTypes", "Name");
            DropColumn("dbo.MembershipTypes", "DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.String());
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            AddColumn("dbo.Customers", "Image", c => c.String());
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ContactNo", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Balance", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "dues", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Username", c => c.String());
            AddColumn("dbo.Carts", "SessionId", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "ConfirmPassword");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
