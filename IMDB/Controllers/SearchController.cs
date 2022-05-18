using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.ViewModels;
using IMDB.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using IMDB.Classes;

namespace IMDB.Controllers
{

    public class SearchController : Controller
    {
      
            private readonly DBContext db = new DBContext();
            UserFunctions user = new UserFunctions();
            GetData get = new GetData();
            Search SearchResult = new ViewModels.Search();

            // GET: Search
            [HttpGet]
            public ActionResult Searching()
            {
                SearchResult.Actors = get.GetActors();
                SearchResult.Directors = get.GetDirectors();
                SearchResult.Movies = get.GetMovies();
                return View(SearchResult);
            }

            [HttpPost]
            public ActionResult Searching(string SearchValue)
        {
            Search SearchResult = new ViewModels.Search();

            user.Splitter(SearchValue, SearchResult);
            return View(SearchResult);
        }

    }
}