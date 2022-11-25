namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "Writer", c => c.String());
            AddColumn("dbo.Movies", "Starring", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Starring");
            DropColumn("dbo.Movies", "Writer");
            DropColumn("dbo.Movies", "Director");
        }
    }
}
