namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartLi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartLineItems", "Size", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartLineItems", "Size");
        }
    }
}
