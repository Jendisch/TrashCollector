namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedEmployee : DbMigration
    {
        public override void Up()
        {

            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Line1Address], [Line2Address], [City], [State], [ZipCode], [FirstName], [LastName]) VALUES (N'6cd42c10-57de-4a4b-842a-55d5035ffb6a', N'admin@onlinetrash.com', 0, N'AO30RFm2dBD8SGzbFq/hqfmGCslsW+db9xUohPT12ZMQw/EZqkCq05CXkbyRvd0dYg==', N'8b0ff62a-f053-427e-8e12-26d240c76c50', N'4145554321', 0, 0, NULL, 1, 0, N'admin@onlinetrash.com', N'555 E St. Paul Ave', NULL, N'Milwaukee', N'WI', N'53202', N'Administrator', N'...')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Line1Address], [Line2Address], [City], [State], [ZipCode], [FirstName], [LastName]) VALUES (N'ef790a8e-14b4-4938-b1d4-5ef48642ab91', N'guest@onlinetrash.com', 0, N'AAoypo6VEpZr/5dtCMU0ezncgEGhT0E26115A505x3ZVV2g1pcNXI6d5FJXzmSKu7A==', N'24a27d4d-2e28-40ab-bb0f-5f08627f1a04', N'4145551234', 0, 0, NULL, 1, 0, N'guest@onlinetrash.com', N'Guest Ave.', NULL, N'MKE', N'WI', N'53201', N'Guest', N'.')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f1b043b7-c3be-43be-8b56-2696c9a74b58', N'Employee')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6cd42c10-57de-4a4b-842a-55d5035ffb6a', N'f1b043b7-c3be-43be-8b56-2696c9a74b58')


");

        }
        
        public override void Down()
        {
        }
    }
}
