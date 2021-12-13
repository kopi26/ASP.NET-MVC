namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateToGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( 'Comedy')");
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( 'Action')");
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( 'Sci-Fic')");
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( 'Fantasy')");
        }
        
        public override void Down()
        {
        }
    }
}
