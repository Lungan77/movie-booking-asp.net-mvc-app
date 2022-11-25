namespace Movie_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypesofMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "TypesofMoviesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "TypesofMoviesId");
            AddForeignKey("dbo.Movies", "TypesofMoviesId", "dbo.TypesofMovies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "TypesofMoviesId", "dbo.TypesofMovies");
            DropIndex("dbo.Movies", new[] { "TypesofMoviesId" });
            DropColumn("dbo.Movies", "TypesofMoviesId");
            DropTable("dbo.TypesofMovies");
        }
    }
}
