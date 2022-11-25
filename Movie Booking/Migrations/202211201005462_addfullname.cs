namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfullname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Full_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Full_Name");
        }
    }
}
