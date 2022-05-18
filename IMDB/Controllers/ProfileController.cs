using IMDB.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

 

namespace IMDB.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DBContext db = new DBContext();
        GetData get = new GetData();


        // GET: Actor
        public ActionResult ActorList()
        {
            var actors = get.GetActors();
            return View(actors);
        }


        //Director
        public async Task<ActionResult> Directorlist()
        {
            List<Models.Director> directors = await get.GetDirectorsAsync();
            return View(directors);
        }


        //movie
        public async Task<ActionResult> Movie()
        {
            List<Models.Movie> movies = await get.GetMoviesAsync();
            return View(movies);
        }

    }
}