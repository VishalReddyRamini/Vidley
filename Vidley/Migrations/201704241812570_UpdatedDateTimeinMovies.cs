namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDateTimeinMovies : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "RealeaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "RealeaseDate", c => c.DateTime(nullable: false));
        }
    }
}
