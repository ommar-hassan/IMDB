using IMDB.Models;
using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMDB.Classes
{
    public class Admin : IAdmin
    {
        private DBContext db = new DBContext();

        /// <summary>
        /// Update Actor Database Data
        /// </summary>
        /// <param name="newActor"></param>
        public void UpdateActorToDatabase(Actor newActor)
        {
            db.Entry(newActor).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Copy data from old actor to new actor
        /// </summary>
        /// <param name="oldActor"></param>
        /// <param name="newActor"></param>
        public void CopyActorData(Actor oldActor, Actor newActor)
        {
            newActor.FirstName = oldActor.FirstName;
            newActor.LastName = oldActor.LastName;
            newActor.Description = oldActor.Description;
            newActor.Age = oldActor.Age;
            newActor.ActorIMG = oldActor.ActorIMG;
        }

        /// <summary>
        /// Delete Director From Movies
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDirectorFromMovies(int id)
        {
            foreach (var item in db.Movies)
            {
                if (item.DirectorID == id)
                {
                    item.DirectorID = null;
                }

            }
        }

        /// <summary>
        /// Delete Movies From Database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMovieFromDatabase(int id)
        {
            var movie = db.Movies.FirstOrDefault(model => model.MovieID == id);
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        /// <summary>
        /// Copy Director Data to new one
        /// </summary>
        /// <param name="oldDirector"></param>
        /// <param name="newDirector"></param>
        public void CopyDirectorData(Director oldDirector, Director newDirector)
        {
            newDirector.FirstName = oldDirector.FirstName;
            newDirector.LastName = oldDirector.LastName;
            newDirector.Description = oldDirector.Description;
            newDirector.Age = oldDirector.Age;
            newDirector.DirectorIMG = oldDirector.DirectorIMG;
        }

        /// <summary>
        /// Update Director to database
        /// </summary>
        /// <param name="newDirector"></param>
        public void UpdateDirectorToDatabase(Director newDirector)
        {
            db.Entry(newDirector).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Search for Data
        /// </summary>
        /// <param name="SearchValue"></param>
        /// <param name="SearchResult"></param>
        /// <param name="SearchSplit"></param>
        public void SearchData(string SearchValue, Search SearchResult, string[] SearchSplit)
        {
            foreach (var item in SearchSplit)
            {
                SearchResult.Actors = db.Actors.Where(Actor => Actor.FirstName.StartsWith(item) || Actor.LastName.StartsWith(item) || SearchValue == null);
                SearchResult.Directors = db.Directors.Where(Director => Director.FirstName.StartsWith(item) || Director.LastName.StartsWith(item) || SearchValue == null);
                SearchResult.Movies = db.Movies.Where(Movie => Movie.MovieName.StartsWith(item) || SearchValue == null);
            }
        }

        /// <summary>
        /// Values Splitter with "space"
        /// </summary>
        /// <param name="SearchValue"></param>
        /// <param name="SearchResult"></param>
        public void Splitter(string SearchValue, Search SearchResult)
        {
            if (SearchValue != null)
            {
                string[] SearchSplit = SearchValue.Split(' ');
                SearchData(SearchValue, SearchResult, SearchSplit);
            }
        }

        /// <summary>
        /// Update User data into database
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserToDatabase(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}