namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trailer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Trailer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Trailer");
        }
    }
}
