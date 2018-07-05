namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipwithdiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "DiscountRate");
        }
    }
}
