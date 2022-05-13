using IMDB.Models;
using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class ViewController : Controller
    {
        private DBContext _context = new DBContext();
        // GET: View
        public ActionResult ActorProfile(int id)
        {
            var actorView = _context.Actors.SingleOrDefault(x => x.ActorID == id);
            if (actorView == null)
                return HttpNotFound();

            return View(actorView);
        }
        public ActionResult DirectorProfile(int id)
        {
            var directorView = _context.Directors.SingleOrDefault(x => x.DirectorID == id);
            if (directorView == null)
                return HttpNotFound();

            return View(directorView);
        }

        public ActionResult MovieProfile(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieID == id);
            if (movie == null)
                return HttpNotFound();

            var movieActors = _context.MovieActors.Where(model => model.MovieID == id);

            var director = movie.Director;
            MovieProfileViewModel profile = new MovieProfileViewModel()
            {
                Movie = movie,
                MovieActor = movieActors,
                Director = director
             
            };
            
            return View(profile);
        }

    }
}