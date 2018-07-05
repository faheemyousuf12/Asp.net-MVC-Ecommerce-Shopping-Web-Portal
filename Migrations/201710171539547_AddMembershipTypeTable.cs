namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "MembershipTypeId");
            AddForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Users", new[] { "MembershipTypeId" });
            DropColumn("dbo.Users", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
