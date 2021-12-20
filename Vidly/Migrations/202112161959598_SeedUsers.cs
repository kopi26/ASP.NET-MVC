namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'65aaf5a2-2ed5-4aaa-9ace-633c0be3fd31', N'admin@vidly.com', 0, N'AKGpqHymnEYO+1+bEE1yopqdN1zeQTPQBxwphTk4DD/ArUyTQNGinWIxB1thdGVnjw==', N'3604affb-e433-45ee-a3dc-c62fc1fd84b2', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'805a84a9-96d5-432e-806a-f4b17081e5c7', N'guest@vidly.com', 0, N'ACsSqprfvedbUo/xas0eUbleU3PYZSBoj3gUwyhJBkDEo4nalp/ZNHL2cHLTAUg/LQ==', N'c2e72874-4c2c-4745-9d64-361df9965b57', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8c7d5f6f-1b2e-4b93-918b-97897d98dce0', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'65aaf5a2-2ed5-4aaa-9ace-633c0be3fd31', N'8c7d5f6f-1b2e-4b93-918b-97897d98dce0')

");
        }
        
        public override void Down()
        {
        }
    }
}
