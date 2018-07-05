namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeRoleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "EmployeeRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "EmployeeRoleId");
            AddForeignKey("dbo.Users", "EmployeeRoleId", "dbo.EmployeeRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "EmployeeRoleId", "dbo.EmployeeRoles");
            DropIndex("dbo.Users", new[] { "EmployeeRoleId" });
            DropColumn("dbo.Users", "EmployeeRoleId");
            DropTable("dbo.EmployeeRoles");
        }
    }
}
