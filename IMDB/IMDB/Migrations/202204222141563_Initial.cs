namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.ActorID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        MovieID_MovieID = c.Int(),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Movies", t => t.MovieID_MovieID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.MovieID_MovieID)
                .Index(t => t.UserID_UserID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        MovieIMG = c.Binary(),
                        DirectorID_DirectorID = c.Int(),
                    })
                .PrimaryKey(t => t.MovieID)
                .ForeignKey("dbo.Directors", t => t.DirectorID_DirectorID)
                .Index(t => t.DirectorID_DirectorID);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.DirectorID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MovieID_MovieID = c.Int(),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieID_MovieID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.MovieID_MovieID)
                .Index(t => t.UserID_UserID);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActorID_ActorID = c.Int(),
                        MovieID_MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.ActorID_ActorID)
                .ForeignKey("dbo.Movies", t => t.MovieID_MovieID)
                .Index(t => t.ActorID_ActorID)
                .Index(t => t.MovieID_MovieID);
            
            CreateTable(
                "dbo.UserFavoriteActors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActorID_ActorID = c.Int(),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.ActorID_ActorID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.ActorID_ActorID)
                .Index(t => t.UserID_UserID);
            
            CreateTable(
                "dbo.UserFavoriteDirectors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DirectorID_DirectorID = c.Int(),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Directors", t => t.DirectorID_DirectorID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.DirectorID_DirectorID)
                .Index(t => t.UserID_UserID);
            
            CreateTable(
                "dbo.UserFavoriteMovies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MovieID_MovieID = c.Int(),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieID_MovieID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.MovieID_MovieID)
                .Index(t => t.UserID_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFavoriteMovies", "UserID_UserID", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteMovies", "MovieID_MovieID", "dbo.Movies");
            DropForeignKey("dbo.UserFavoriteDirectors", "UserID_UserID", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteDirectors", "DirectorID_DirectorID", "dbo.Directors");
            DropForeignKey("dbo.UserFavoriteActors", "UserID_UserID", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteActors", "ActorID_ActorID", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "MovieID_MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "ActorID_ActorID", "dbo.Actors");
            DropForeignKey("dbo.Likes", "UserID_UserID", "dbo.Users");
            DropForeignKey("dbo.Likes", "MovieID_MovieID", "dbo.Movies");
            DropForeignKey("dbo.Comments", "UserID_UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "MovieID_MovieID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "DirectorID_DirectorID", "dbo.Directors");
            DropIndex("dbo.UserFavoriteMovies", new[] { "UserID_UserID" });
            DropIndex("dbo.UserFavoriteMovies", new[] { "MovieID_MovieID" });
            DropIndex("dbo.UserFavoriteDirectors", new[] { "UserID_UserID" });
            DropIndex("dbo.UserFavoriteDirectors", new[] { "DirectorID_DirectorID" });
            DropIndex("dbo.UserFavoriteActors", new[] { "UserID_UserID" });
            DropIndex("dbo.UserFavoriteActors", new[] { "ActorID_ActorID" });
            DropIndex("dbo.MovieActors", new[] { "MovieID_MovieID" });
            DropIndex("dbo.MovieActors", new[] { "ActorID_ActorID" });
            DropIndex("dbo.Likes", new[] { "UserID_UserID" });
            DropIndex("dbo.Likes", new[] { "MovieID_MovieID" });
            DropIndex("dbo.Movies", new[] { "DirectorID_DirectorID" });
            DropIndex("dbo.Comments", new[] { "UserID_UserID" });
            DropIndex("dbo.Comments", new[] { "MovieID_MovieID" });
            DropTable("dbo.UserFavoriteMovies");
            DropTable("dbo.UserFavoriteDirectors");
            DropTable("dbo.UserFavoriteActors");
            DropTable("dbo.MovieActors");
            DropTable("dbo.Likes");
            DropTable("dbo.Users");
            DropTable("dbo.Directors");
            DropTable("dbo.Movies");
            DropTable("dbo.Comments");
            DropTable("dbo.Actors");
        }
    }
}
