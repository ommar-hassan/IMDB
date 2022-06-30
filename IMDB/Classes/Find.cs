using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Classes
{
    public class Find
    {
        private DBContext db = new DBContext();

        public Actor FindActorByID(int? id)
        {
            return db.Actors.SingleOrDefault(a => a.ActorID == id);
        }

        public Director FindDirectorByID(int? id)
        {
            return db.Directors.SingleOrDefault(a => a.DirectorID == id);
        }

        public Movie FindMovieByID(int? id)
        {
            return db.Movies.SingleOrDefault(a => a.MovieID == id);
        }

        public MovieActor FindMovieActorByID(int idMovie, int idActor)
        {
            return db.MovieActors.SingleOrDefault(model => model.MovieID == idMovie && model.ActorID == idActor);
        }

        public IQueryable<MovieActor> FindMovieActorsByID(int id)
        {
            return db.MovieActors.Where(x => x.ActorID == id);
        }

        public IQueryable<Movie> FindMovieDirectorsByID(int id)
        {
            return db.Movies.Where(x => x.DirectorID == id);
        }
    }
}