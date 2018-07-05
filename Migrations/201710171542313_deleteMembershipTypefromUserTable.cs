namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteMembershipTypefromUserTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Users", new[] { "MembershipTypeId" });
            DropColumn("dbo.Users", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "MembershipTypeId");
            AddForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
