using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.ViewModels;
using IMDB.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMDB.Controllers
{

    public class SearchController : Controller
    {
      
            DBContext db = new DBContext();
            Search SearchResult = new ViewModels.Search();
            // GET: Search
            [HttpGet]
            public ActionResult Searching()
            {
                SearchResult.Actors = db.Actors.ToList();

                SearchResult.Directors = db.Directors.ToList();
                SearchResult.Movies = db.Movies.ToList();
                return View(SearchResult);
            }
            [HttpPost]

            public ActionResult Searching(string SearchValue)
            {
                Search SearchResult = new ViewModels.Search();

                if (SearchValue == null)
                {

                }
                else
                {

                    string[] SearchSplit = SearchValue.Split(' ');
                    foreach (var item in SearchSplit)
                    {
                        SearchResult.Actors = db.Actors.Where(Actor => Actor.FirstName.StartsWith(item) || Actor.LastName.StartsWith(item) || SearchValue == null);
                        SearchResult.Directors = db.Directors.Where(Director => Director.FirstName.StartsWith(item) || Director.LastName.StartsWith(item) || SearchValue == null);
                        SearchResult.Movies = db.Movies.Where(Movie => Movie.MovieName.StartsWith(item) || SearchValue == null);
                    }
                }
                return View(SearchResult);
            }

        }
}