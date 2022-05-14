namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixErros : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieActors", "ActorID", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "MovieID", "dbo.Movies");
            DropIndex("dbo.MovieActors", new[] { "MovieID" });
            DropIndex("dbo.MovieActors", new[] { "ActorID" });
            DropPrimaryKey("dbo.MovieActors");
            AddColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Actors", "Description", c => c.String());
            AlterColumn("dbo.Directors", "Description", c => c.String());
            AlterColumn("dbo.MovieActors", "MovieID", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieActors", "ActorID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MovieActors", new[] { "ActorID", "MovieID" });
            CreateIndex("dbo.MovieActors", "ActorID");
            CreateIndex("dbo.MovieActors", "MovieID");
            AddForeignKey("dbo.MovieActors", "ActorID", "dbo.Actors", "ActorID", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors", "MovieID", "dbo.Movies", "MovieID", cascadeDelete: true);
            DropColumn("dbo.MovieActors", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieActors", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.MovieActors", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "ActorID", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "MovieID" });
            DropIndex("dbo.MovieActors", new[] { "ActorID" });
            DropPrimaryKey("dbo.MovieActors");
            AlterColumn("dbo.MovieActors", "ActorID", c => c.Int());
            AlterColumn("dbo.MovieActors", "MovieID", c => c.Int());
            AlterColumn("dbo.Directors", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Actors", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "Description");
            AddPrimaryKey("dbo.MovieActors", "ID");
            CreateIndex("dbo.MovieActors", "ActorID");
            CreateIndex("dbo.MovieActors", "MovieID");
            AddForeignKey("dbo.MovieActors", "MovieID", "dbo.Movies", "MovieID");
            AddForeignKey("dbo.MovieActors", "ActorID", "dbo.Actors", "ActorID");
        }
    }
}
