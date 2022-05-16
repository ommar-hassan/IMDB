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

         DBContext db = new DBContext();

        // GET: Actor
        public ActionResult ActorList()
        {
            var data = db.Actors.ToList();
            return View(data);
        }



        //Director
        public async Task<ActionResult> Directorlist()
        {
            var allDirectors = await db.Directors.ToListAsync();
            return View(allDirectors);
        }


        //movie
        public async Task<ActionResult> Movie()
        {
            var allMovies = await db.Movies.ToListAsync();
            return View(allMovies);
        }

    }
}