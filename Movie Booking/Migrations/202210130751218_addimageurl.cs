namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ImageURL");
        }
    }
}
