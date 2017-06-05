namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Line1Address], [Line2Address], [City], [State], [ZipCode], [FirstName], [LastName]) VALUES (N'a8d55b6a-53d5-4358-a245-a0212a9d01a4', N'admin@onlinetrash.com', 0, N'ACbyTPUwdgZw+oaJ8iuhfZp3tX5zeurE4YN9Obq39YwfsaL3s4FD0MZ0vN/Cukdoaw==', N'98f2eba2-36ad-422d-a56f-e54d64af1171', N'4145555000', 0, 0, NULL, 1, 0, N'Administrator Employee', N'555 E St. Paul Ave', NULL, N'Milwaukee', N'WI', N'53201', N'Administrator', N'Employee')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Line1Address], [Line2Address], [City], [State], [ZipCode], [FirstName], [LastName]) VALUES (N'b9e3626a-afc3-4fb5-850b-b370dde390e0', N'guest@onlinetrash.com', 0, N'ABTSWDp1/eHTTw5Vniep/ehfTN2npExxvW9SNZHdEep0BwDuowEwqqLvBcaxvXW47Q==', N'd649a2be-4735-4832-b3bd-cc6b599412a0', N'4145555555', 0, 0, NULL, 1, 0, N'Guest .', N'Guest Ave', N'Apt 111', N'Milwaukee', N'WI', N'53202', N'Guest', N'.')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f6ff097e-5386-4ac2-bd63-2d769be7863d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a8d55b6a-53d5-4358-a245-a0212a9d01a4', N'f6ff097e-5386-4ac2-bd63-2d769be7863d')

");

        }
        
        public override void Down()
        {
        }
    }
}
