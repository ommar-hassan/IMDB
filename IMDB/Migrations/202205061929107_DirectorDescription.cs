namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DirectorDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Directors", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "Description");
        }
    }
}
