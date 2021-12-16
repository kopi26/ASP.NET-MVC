namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredInModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.GenreTypes", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GenreTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
        }
    }
}
