namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Date");
        }
    }
}
