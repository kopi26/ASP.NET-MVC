namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalMovie2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RentalMovies", "DateReturned", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RentalMovies", "DateReturned", c => c.DateTime(nullable: false));
        }
    }
}
