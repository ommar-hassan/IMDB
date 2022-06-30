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

        public List<Director> GetDirectors()
        {
            return db.Directors.ToList();
        }

        public AssignsViewModel GetMovieActors()
        {
            return new AssignsViewModel()
            {
                Actors = GetActors(),
                Movies = GetMovies()
            };
        }

        public List<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        public List<Actor> GetActors()
        {
            return db.Actors.ToList();
        }

        public MovieCreationViewModel GetMovieDirectors(Movie movie)
        {
            return new MovieCreationViewModel
            {
                Movie = movie,
                Directors = GetDirectors()
            };
        }

        public async Task<List<Models.Director>> GetDirectorsAsync()
        {
            return await db.Directors.ToListAsync();
        }

        public async Task<List<Models.Movie>> GetMoviesAsync()
        {
            return await db.Movies.ToListAsync();
        }

    }
}