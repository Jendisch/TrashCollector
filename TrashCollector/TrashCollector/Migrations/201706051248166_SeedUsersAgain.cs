namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAgain : DbMigration
    {
        public override void Up()
        {

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Line1Address], [Line2Address], [City], [State], [ZipCode], [FirstName], [LastName]) VALUES (N'2c7b49a7-1419-478e-9f69-1886ceffff77', N'admin@onlinetrash.com', 0, N'AJofhTD0EdgUv947Pz37YCM2IrEOwLzaHIRsoLTS/JzKkrM56Dfz/tfhf8IjtD1B4Q==', N'24c50ab7-75e0-4931-acd6-0b495d45a43d', N'4145557765', 0, 0, NULL, 1, 0, N'admin@onlinetrash.com', N'555 E St. Paul Ave', NULL, N'Milwaukee', N'WI', N'53201', N'Admin', N'Employee')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Line1Address], [Line2Address], [City], [State], [ZipCode], [FirstName], [LastName]) VALUES (N'b9e3626a-afc3-4fb5-850b-b370dde390e0', N'guest@onlinetrash.com', 0, N'ABTSWDp1/eHTTw5Vniep/ehfTN2npExxvW9SNZHdEep0BwDuowEwqqLvBcaxvXW47Q==', N'd649a2be-4735-4832-b3bd-cc6b599412a0', N'4145555555', 0, 0, NULL, 1, 0, N'Guest .', N'Guest Ave', N'Apt 111', N'Milwaukee', N'WI', N'53202', N'Guest', N'.')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f6ff097e-5386-4ac2-bd63-2d769be7863d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2c7b49a7-1419-478e-9f69-1886ceffff77', N'f6ff097e-5386-4ac2-bd63-2d769be7863d')


");

        }
        
        public override void Down()
        {
        }
    }
}
