using IMDB.Models;
using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IMDB.Classes
{
    public class GetData
    {
        private DBContext db = new DBContext();

        /// <summary>
        /// Directors getter as a list
        /// </summary>
        /// <returns></returns>
        public List<Director> GetDirectors()
        {
            return db.Directors.ToList();
        }

        /// <summary>
        /// Movies and Actors Getter
        /// </summary>
        /// <returns></returns>
        public AssignsViewModel GetMovieActors()
        {
            return new AssignsViewModel()
            {
                Actors = GetActors(),
                Movies = GetMovies()
            };
        }

        /// <summary>
        /// Movies getter as a list
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        /// <summary>
        /// Actors getter as a list
        /// </summary>
        /// <returns></returns>
        public List<Actor> GetActors()
        {
            return db.Actors.ToList();
        }

        /// <summary>
        /// Get Create Movie View Data
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public MovieCreationViewModel GetMovieDirectors(Movie movie)
        {
            return new MovieCreationViewModel
            {
                Movie = movie,
                Directors = GetDirectors()
            };
        }

        /// <summary>
        /// get Directors as a list But Async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Models.Director>> GetDirectorsAsync()
        {
            return await db.Directors.ToListAsync();
        }

        /// <summary>
        /// get Movies as a list But Async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Models.Movie>> GetMoviesAsync()
        {
            return await db.Movies.ToListAsync();
        }

    }
}