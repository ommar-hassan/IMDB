using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMDB
{

    public class DBContext : DbContext
    {
        public DBContext() : base("IMDb")
        {
        }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserFavoriteActor> UserFavoriteActors { get; set; }

        public DbSet<UserFavoriteDirector> UserFavoriteDirectors { get; set; }

        public DbSet<UserFavoriteMovie> UserFavoriteMovies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(movieActorID => new { movieActorID.ActorID, movieActorID.MovieID });
        }

    }
}    
