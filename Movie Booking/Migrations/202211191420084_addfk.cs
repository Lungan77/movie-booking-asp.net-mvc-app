namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "MovieId", "dbo.Movies");
            DropIndex("dbo.Clients", new[] { "MovieId" });
            AddColumn("dbo.Bookings", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Email", c => c.String());
            AddColumn("dbo.Clients", "UserId", c => c.String());
            CreateIndex("dbo.Bookings", "ClientId");
            AddForeignKey("dbo.Bookings", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            DropColumn("dbo.Clients", "MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "MovieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bookings", "ClientId", "dbo.Clients");
            DropIndex("dbo.Bookings", new[] { "ClientId" });
            DropColumn("dbo.Clients", "UserId");
            DropColumn("dbo.Clients", "Email");
            DropColumn("dbo.Bookings", "ClientId");
            CreateIndex("dbo.Clients", "MovieId");
            AddForeignKey("dbo.Clients", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
