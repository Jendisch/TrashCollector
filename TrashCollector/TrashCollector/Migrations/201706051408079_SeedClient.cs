namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedClient : DbMigration
    {
        public override void Up()
        {

            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Line1Address], [Line2Address], [City], [State], [ZipCode], [FirstName], [LastName]) VALUES (N'6bafe470-70d1-45bc-8525-595cb898f197', N'guest@onlinetrash.com', 0, N'ANTxDHT+hEBarJXsFIFhqW7UJ08GiXnWefCNNzSr0FJBmeOQGv7kZjWk8ZKR4a2O5Q==', N'8a36271c-6574-4c93-91c8-9714eb1fbe49', N'4145550987', 0, 0, NULL, 1, 0, N'guest@onlinetrash.com', N'765 W Wisconsin Ave.', NULL, N'Milwaukee', N'WI', N'53202', N'Guest', N'.')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'390bc76f-e0b6-413e-9c68-1eba3d2be8ba', N'Client')


");

        }
        
        public override void Down()
        {
        }
    }
}
