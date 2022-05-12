namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "Description");
        }
    }
}
