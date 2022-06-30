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

        public void CopyActorData(Actor oldActor, Actor newActor)
        {
            newActor.FirstName = oldActor.FirstName;
            newActor.LastName = oldActor.LastName;
            newActor.Description = oldActor.Description;
            newActor.Age = oldActor.Age;
            newActor.ActorIMG = oldActor.ActorIMG;
        }

        public void CopyDirectorData(Director oldDirector, Director newDirector)
        {
            newDirector.FirstName = oldDirector.FirstName;
            newDirector.LastName = oldDirector.LastName;
            newDirector.Description = oldDirector.Description;
            newDirector.Age = oldDirector.Age;
            newDirector.DirectorIMG = oldDirector.DirectorIMG;
        }

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

        public void DeleteMovieFromDatabase(int id)
        {
            var movie = db.Movies.FirstOrDefault(model => model.MovieID == id);
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        public void UpdateDirectorToDatabase(Director newDirector)
        {
            db.Entry(newDirector).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateUserToDatabase(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateActorToDatabase(Actor newActor)
        {
            db.Entry(newActor).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void SearchData(string SearchValue, Search SearchResult, string[] SearchSplit)
        {
            foreach (var item in SearchSplit)
            {
                SearchResult.Actors = db.Actors.Where(Actor => Actor.FirstName.StartsWith(item) || Actor.LastName.StartsWith(item) || SearchValue == null);
                SearchResult.Directors = db.Directors.Where(Director => Director.FirstName.StartsWith(item) || Director.LastName.StartsWith(item) || SearchValue == null);
                SearchResult.Movies = db.Movies.Where(Movie => Movie.MovieName.StartsWith(item) || SearchValue == null);
            }
        }

        public void Splitter(string SearchValue, Search SearchResult)
        {
            if (SearchValue != null)
            {
                string[] SearchSplit = SearchValue.Split(' ');
                SearchData(SearchValue, SearchResult, SearchSplit);
            }
        }

        
    }
}