namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.DatesId, cascadeDelete: true)
                .Index(t => t.DatesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "DatesId", "dbo.Dates");
            DropIndex("dbo.Bookings", new[] { "DatesId" });
            DropTable("dbo.Bookings");
        }
    }
}
