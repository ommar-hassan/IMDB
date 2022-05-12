namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ActorIMG", c => c.Binary());
            AddColumn("dbo.Directors", "DirectorIMG", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "DirectorIMG");
            DropColumn("dbo.Actors", "ActorIMG");
        }
    }
}
