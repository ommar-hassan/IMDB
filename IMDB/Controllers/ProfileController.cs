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

         DBContext _context = new DBContext();

        // GET: Actor
        public ActionResult ActorList()
        {
            var data = _context.Actors.ToList();
            return View(data);
        }

        //movie
        public async Task<ActionResult> Movie()
        {
            var allMovies = await _context.Movies.ToListAsync();
            return View();
        }

        //Director
        public async Task<ActionResult> Directorlist()
        {
            var allDirectors = await _context.Directors.ToListAsync();
            return View(allDirectors);
        }

    }
}