using IMDB.Models;
using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Classes
{
    public class UserFunctions : IAdmin
    {
        private DBContext db = new DBContext();

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