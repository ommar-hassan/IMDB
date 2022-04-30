namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "Movie_MovieID", newName: "MovieID");
            RenameColumn(table: "dbo.Comments", name: "UserID_UserID", newName: "UserID");
            RenameColumn(table: "dbo.Likes", name: "MovieID_MovieID", newName: "MovieID");
            RenameColumn(table: "dbo.Likes", name: "UserID_UserID", newName: "UserID");
            RenameColumn(table: "dbo.MovieActors", name: "ActorID_ActorID", newName: "ActorID");
            RenameColumn(table: "dbo.MovieActors", name: "MovieID_MovieID", newName: "MovieID");
            RenameColumn(table: "dbo.UserFavoriteActors", name: "ActorID_ActorID", newName: "ActorID");
            RenameColumn(table: "dbo.UserFavoriteActors", name: "UserID_UserID", newName: "UserID");
            RenameColumn(table: "dbo.UserFavoriteDirectors", name: "DirectorID_DirectorID", newName: "DirectorID");
            RenameColumn(table: "dbo.UserFavoriteDirectors", name: "UserID_UserID", newName: "UserID");
            RenameColumn(table: "dbo.UserFavoriteMovies", name: "MovieID_MovieID", newName: "MovieID");
            RenameColumn(table: "dbo.UserFavoriteMovies", name: "UserID_UserID", newName: "UserID");
            RenameIndex(table: "dbo.Comments", name: "IX_Movie_MovieID", newName: "IX_MovieID");
            RenameIndex(table: "dbo.Comments", name: "IX_UserID_UserID", newName: "IX_UserID");
            RenameIndex(table: "dbo.Likes", name: "IX_UserID_UserID", newName: "IX_UserID");
            RenameIndex(table: "dbo.Likes", name: "IX_MovieID_MovieID", newName: "IX_MovieID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_MovieID_MovieID", newName: "IX_MovieID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_ActorID_ActorID", newName: "IX_ActorID");
            RenameIndex(table: "dbo.UserFavoriteActors", name: "IX_UserID_UserID", newName: "IX_UserID");
            RenameIndex(table: "dbo.UserFavoriteActors", name: "IX_ActorID_ActorID", newName: "IX_ActorID");
            RenameIndex(table: "dbo.UserFavoriteDirectors", name: "IX_UserID_UserID", newName: "IX_UserID");
            RenameIndex(table: "dbo.UserFavoriteDirectors", name: "IX_DirectorID_DirectorID", newName: "IX_DirectorID");
            RenameIndex(table: "dbo.UserFavoriteMovies", name: "IX_UserID_UserID", newName: "IX_UserID");
            RenameIndex(table: "dbo.UserFavoriteMovies", name: "IX_MovieID_MovieID", newName: "IX_MovieID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserFavoriteMovies", name: "IX_MovieID", newName: "IX_MovieID_MovieID");
            RenameIndex(table: "dbo.UserFavoriteMovies", name: "IX_UserID", newName: "IX_UserID_UserID");
            RenameIndex(table: "dbo.UserFavoriteDirectors", name: "IX_DirectorID", newName: "IX_DirectorID_DirectorID");
            RenameIndex(table: "dbo.UserFavoriteDirectors", name: "IX_UserID", newName: "IX_UserID_UserID");
            RenameIndex(table: "dbo.UserFavoriteActors", name: "IX_ActorID", newName: "IX_ActorID_ActorID");
            RenameIndex(table: "dbo.UserFavoriteActors", name: "IX_UserID", newName: "IX_UserID_UserID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_ActorID", newName: "IX_ActorID_ActorID");
            RenameIndex(table: "dbo.MovieActors", name: "IX_MovieID", newName: "IX_MovieID_MovieID");
            RenameIndex(table: "dbo.Likes", name: "IX_MovieID", newName: "IX_MovieID_MovieID");
            RenameIndex(table: "dbo.Likes", name: "IX_UserID", newName: "IX_UserID_UserID");
            RenameIndex(table: "dbo.Comments", name: "IX_UserID", newName: "IX_UserID_UserID");
            RenameIndex(table: "dbo.Comments", name: "IX_MovieID", newName: "IX_Movie_MovieID");
            RenameColumn(table: "dbo.UserFavoriteMovies", name: "UserID", newName: "UserID_UserID");
            RenameColumn(table: "dbo.UserFavoriteMovies", name: "MovieID", newName: "MovieID_MovieID");
            RenameColumn(table: "dbo.UserFavoriteDirectors", name: "UserID", newName: "UserID_UserID");
            RenameColumn(table: "dbo.UserFavoriteDirectors", name: "DirectorID", newName: "DirectorID_DirectorID");
            RenameColumn(table: "dbo.UserFavoriteActors", name: "UserID", newName: "UserID_UserID");
            RenameColumn(table: "dbo.UserFavoriteActors", name: "ActorID", newName: "ActorID_ActorID");
            RenameColumn(table: "dbo.MovieActors", name: "MovieID", newName: "MovieID_MovieID");
            RenameColumn(table: "dbo.MovieActors", name: "ActorID", newName: "ActorID_ActorID");
            RenameColumn(table: "dbo.Likes", name: "UserID", newName: "UserID_UserID");
            RenameColumn(table: "dbo.Likes", name: "MovieID", newName: "MovieID_MovieID");
            RenameColumn(table: "dbo.Comments", name: "UserID", newName: "UserID_UserID");
            RenameColumn(table: "dbo.Comments", name: "MovieID", newName: "Movie_MovieID");
        }
    }
}
