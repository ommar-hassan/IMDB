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

        /// <summary>
        /// Find Actor By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Actor FindActorByID(int? id)
        {
            return db.Actors.SingleOrDefault(a => a.ActorID == id);
        }

        /// <summary>
        /// Find Director By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Director FindDirectorByID(int? id)
        {
            return db.Directors.SingleOrDefault(a => a.DirectorID == id);
        }

        /// <summary>
        /// Find Movie By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movie FindMovieByID(int? id)
        {
            return db.Movies.SingleOrDefault(a => a.MovieID == id);
        }

        /// <summary>
        /// Find Movie Actor by ID
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public MovieActor FindMovieActorByID(int idMovie, int idActor)
        {
            return db.MovieActors.SingleOrDefault(model => model.MovieID == idMovie && model.ActorID == idActor);
        }


        /// <summary>
        /// Find All Actors in Movie Actors By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<MovieActor> FindMovieActorsByID(int id)
        {
            return db.MovieActors.Where(x => x.ActorID == id);
        }

        /// <summary>
        /// Find All Directors in Movie Actors By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Movie> FindMovieDirectorsByID(int id)
        {
            return db.Movies.Where(x => x.DirectorID == id);
        }
    }
}