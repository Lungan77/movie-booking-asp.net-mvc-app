namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie_description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Description");
        }
    }
}
