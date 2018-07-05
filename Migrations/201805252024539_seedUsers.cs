namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'f0565f2e-287e-4eec-8d6a-42c3542d0311', N'ali1234', N'AIFl/dr96M1dE57twUpEmHJpY6qa8BXAeeLmM5ty2hgpgYgy8KW5vRg+hxJnhvA8Tg==', N'22881e57-7c26-43c6-ad2a-8fc952ca5b6c', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'f3c90f65-9dab-47c4-9e7f-effdf870af97', N'Admin', N'AJSakddVjSZeif127iFbjZuq1RvLSARgy7iQhe7zBWDHmOyaVllx5D/nXkAJk6h/fg==', N'06f2abf7-b5e8-47d2-8076-4d56865172f2', N'ApplicationUser')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'effe03e3-0da6-4d93-a2cf-da1de8afd90b', N'ManageBackend')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f3c90f65-9dab-47c4-9e7f-effdf870af97', N'effe03e3-0da6-4d93-a2cf-da1de8afd90b')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
