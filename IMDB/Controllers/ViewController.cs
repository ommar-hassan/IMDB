using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.ViewModels;
namespace IMDB.Controllers
{
    public class ViewController : Controller
    {
        private DBContext db = new DBContext();
        // GET: View
        
        public ActionResult ActorProfile(int id)
        {
            MovieActor particpations = new MovieActor();
            var actorView = db.Actors.SingleOrDefault(x => x.ActorID == id);
            var actor_movie = db.MovieActors.Where(x => x.ActorID == id).ToList();
            Actor_Movie actorProfile = new Actor_Movie
            {
                Actors = actorView,
                MovieActors = actor_movie
                
            };
            if (actorProfile == null)
                return HttpNotFound();

            return View(actorProfile);
        }
        public ActionResult DirectorProfile(int id)
        {

            var directorView = db.Directors.SingleOrDefault(x => x.DirectorID == id);
            var director_movie = db.Movies.Where(x => x.DirectorID == id).ToList();
            Director_Movie directorProfile = new Director_Movie
            {
                Directors = directorView,
                Movies = director_movie
 
            };
            if (directorProfile == null)
                return HttpNotFound();

            return View(directorProfile);
        }


    }
}