namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Description", c => c.String());
            AddColumn("dbo.Movies", "Description", c => c.String());
            AddColumn("dbo.Directors", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "Description");
            DropColumn("dbo.Movies", "Description");
            DropColumn("dbo.Actors", "Description");
        }
    }
}
