namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreidremovemovies : DbMigration
    {
        public override void Up()
        {
            // Sql("ALTER TABLE Movies Rename Genre");
            //Sql("ALTER TABLE Movies DROP COLUMN Genre_Id");
            //   Sql("ALTER TABLE dbo.Movies ADD CONSTRAINT dbo.Movies_dbo.Genres_GenreId FOREIGN KEY (GenreId) REFERENCES Persons(Id)");

       //     DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
        }
    }
}
