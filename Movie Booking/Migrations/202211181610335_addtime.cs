namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dates", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dates", "Time");
        }
    }
}
