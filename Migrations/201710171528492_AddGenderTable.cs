namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "GenderId");
            AddForeignKey("dbo.Users", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropColumn("dbo.Users", "GenderId");
            DropTable("dbo.Genders");
        }
    }
}
