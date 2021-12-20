namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalMovie1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRental = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.RentalMovies", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.RentalMovies", new[] { "Movie_Id" });
            DropIndex("dbo.RentalMovies", new[] { "Customer_Id" });
            DropTable("dbo.RentalMovies");
        }
    }
}
