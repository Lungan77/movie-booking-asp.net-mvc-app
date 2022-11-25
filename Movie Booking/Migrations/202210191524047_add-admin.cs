namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadmin : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb754f4b-9fa6-4920-8940-2413c3d8d4cb', N'admin@admin', 0, N'ACscdg2rZxqjezUSM1wT+5HmJXbwpGeHcCoZZ5Tth8Sm5Pj1Zt1UxfJ8asG/6UauRg==', N'f3d53cd1-10b5-4dae-a677-705cddaeff09', NULL, 0, 0, NULL, 1, 0, N'admin@admin')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Client')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb754f4b-9fa6-4920-8940-2413c3d8d4cb', N'1')");
        }
        
        public override void Down()
        {
        }
    }
}
