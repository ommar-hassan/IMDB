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
    }
}