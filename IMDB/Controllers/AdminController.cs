using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using IMDB.ViewModels;
using System.Data.Entity;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    public class AdminController : Controller
    {
        private DBContext db = new DBContext();


        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewMovie()
        {

            var director = db.Directors.ToList();

            MovieCreationViewModel movieDirectorsViewModel = new MovieCreationViewModel
            {
                Directors = director
            };

            return View(movieDirectorsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMovie(HttpPostedFileBase movieImage, MovieCreationViewModel movieDirectorsViewModel)
        {

            if (!ModelState.IsValid)
            {
                var director = db.Directors.ToList();
                movieDirectorsViewModel.Directors = director;

                return View("NewMovie", movieDirectorsViewModel);
            }
            if (movieImage != null)
            {
                MemoryStream target = new MemoryStream();
                movieImage.InputStream.CopyTo(target);
                byte[] movieImageByteArray = target.ToArray();

                movieDirectorsViewModel.Movie.MovieIMG = movieImageByteArray;
            }

            db.Movies.Add(movieDirectorsViewModel.Movie);
            db.SaveChanges();

            TempData["Message"] = "Created Successfully";
            return RedirectToAction("NewMovie"); // After create go to NewMovie
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewDirector()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewDirector(HttpPostedFileBase directorImage, Director director)
        {

            if (ModelState.IsValid)
            {
                if (directorImage != null)
                {           
                    MemoryStream target = new MemoryStream();
                    directorImage.InputStream.CopyTo(target);
                    byte[] directorImageByteArray = target.ToArray();
                    director.DirectorIMG = directorImageByteArray;
                }

                db.Directors.Add(director);
                db.SaveChanges();
                TempData["Message"] = "Created Successfully";
                return RedirectToAction("NewDirector");
            }

            return View("NewDirector");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewActor()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewActor(HttpPostedFileBase actorImage, Actor actor)
        {
            

            if (ModelState.IsValid)
            {
                if (actorImage != null)
                {
                MemoryStream target = new MemoryStream();
                actorImage.InputStream.CopyTo(target);
                byte[] actorImageByteArray = target.ToArray();
                actor.ActorIMG = actorImageByteArray;
                }

                db.Actors.Add(actor);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Created successfully!";
                return RedirectToAction("NewActor");
            }

            return View("NewActor");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult MovieToActor()
        {

            var actor = db.Actors.ToList();
            var movie = db.Movies.ToList();

            AssignsViewModel movieAndActor = new AssignsViewModel()
            {
                Actors = actor,
                Movies = movie
            };


            return View(movieAndActor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieToActor(AssignsViewModel movieAndActor)
        {

            if (!ModelState.IsValid)
            {
                var actor = db.Actors.ToList();
                movieAndActor.Actors = actor;

                var movie = db.Movies.ToList();
                movieAndActor.Movies = movie;

                return View(/*  " View Name " , */ movieAndActor);
            }

            if (db.MovieActors.Where(model => model.ActorID == movieAndActor.MovieActor.ActorID && model.MovieID == movieAndActor.MovieActor.MovieID).Count() > 0)
            {

                TempData["Message"] = "This Actor is already Assigned";

                return RedirectToAction("MovieToActor");

            }
            db.MovieActors.Add(movieAndActor.MovieActor);
            db.SaveChanges();

            return RedirectToAction("NewMovie"); // "MovieDetails View"
        }


        // update Actor

        [HttpGet]
        public ActionResult ActorsEdit(int? id)
        {
            if (id != null)
            {
                var actor = db.Actors.SingleOrDefault(a => a.ActorID == id);
                if (actor == null)      //checking integirty  
                {
                    return HttpNotFound();
                }
                Actor ActorData = new Actor         // passing required Actor Data for the update
                {
                    ActorID = actor.ActorID,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Description = actor.Description,
                    Age = actor.Age

                };
                Session["ActorID"] = ActorData.ActorID;
                return View(ActorData);
            }

            else
            {
                return RedirectToAction("ActorList");
            }
        }

        [HttpPost]
        public ActionResult ActorsEdit(Actor oldActor)
        {

            if (ModelState.IsValid)
            {
                Actor newActor = new Actor();
                newActor.ActorID = (int)Session["ActorID"];
                newActor = db.Actors.SingleOrDefault(a => a.ActorID == newActor.ActorID);

                newActor.FirstName = oldActor.FirstName;
                newActor.LastName = oldActor.LastName;
                newActor.Description = oldActor.Description;
                newActor.Age = oldActor.Age;
                // actorView.ActorIMG = tempActor.ActorIMG;

                db.Entry(newActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ActorProfile", "View", new { id = newActor.ActorID });
            }

            return View();
        }

        public ActionResult DeleteActor(int id)
        {
            var actor = db.Actors.SingleOrDefault(a => a.ActorID == id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("ActorList", "Profile");
        }

        [HttpGet]
        public ActionResult DirectorsEdit(int? id)
        {
            if (id != null)
            {
                var director = db.Directors.SingleOrDefault(a => a.DirectorID == id);
                if (director == null)      //checking integirty  
                {
                    return HttpNotFound();
                }
                Director directorData = new Director         // passing required Actor Data for the update
                {
                    DirectorID = director.DirectorID,
                    FirstName = director.FirstName,
                    LastName = director.LastName,
                    Description = director.Description,
                    Age = director.Age

                };
                Session["DirectorID"] = directorData.DirectorID;
                return View(directorData);
            }

            else
            {
                return RedirectToAction("DirectorList");
            }
        }

        [HttpPost]
        public ActionResult DirectorsEdit(Director oldDirector, HttpPostedFileBase image)
        {


            if (ModelState.IsValid)
            {
                MemoryStream target = new MemoryStream();
                image.InputStream.CopyTo(target);
                byte[] directorImageByteArray = target.ToArray();           //oldImage convertor
                oldDirector.DirectorIMG = directorImageByteArray;

                Director newDirector = new Director();
                newDirector.DirectorID = (int)Session["DirectorID"];
                newDirector = db.Directors.SingleOrDefault(a => a.DirectorID == newDirector.DirectorID);

                newDirector.FirstName = oldDirector.FirstName;
                newDirector.LastName = oldDirector.LastName;
                newDirector.Description = oldDirector.Description;
                newDirector.Age = oldDirector.Age;
                newDirector.DirectorIMG = oldDirector.DirectorIMG;

                db.Entry(newDirector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DirectorProfile", "View", new { id = newDirector.DirectorID });
            }

            return View();
        }


        public ActionResult DeleteDriector(int id)
        {
            var director = db.Directors.SingleOrDefault(a => a.DirectorID == id);
            foreach (var item in db.Movies)
            {
                if (item.DirectorID == id)
                {
                    item.DirectorID = null;
                }

            }
            db.Directors.Remove(director);
            db.SaveChanges();
            return RedirectToAction("DirectorList", "Profile");
        }

        [HttpGet]
        public ActionResult MovieEdit(int? id)
        {
            if (id != null)
            {
                var movie = db.Movies.SingleOrDefault(a => a.MovieID == id);
                var director = db.Directors.ToList();
                if (movie == null)      //checking integirty  
                {
                    return HttpNotFound();
                }
                MovieCreationViewModel movieData = new MovieCreationViewModel         // passing required Actor Data for the update
                {
                    Movie = movie,
                    Directors = director
                 };

                Session["MovieID"] = movieData.Movie.MovieID;
                return View(movieData);
            }

            else
            {
                return RedirectToAction("Movie");
            }
        }
        [HttpPost]
        public ActionResult MovieEdit(MovieCreationViewModel oldMovie, HttpPostedFileBase image)
        {


            if (ModelState.IsValid)
            {
                MemoryStream target = new MemoryStream();
                image.InputStream.CopyTo(target);
                byte[] directorImageByteArray = target.ToArray();           //oldImage convertor
                oldMovie.Movie.MovieIMG = directorImageByteArray;

                Movie newMovie = new Movie();
                newMovie.MovieID = (int)Session["MovieID"];                                 
                newMovie = db.Movies.SingleOrDefault(a => a.MovieID == newMovie.MovieID);   //creating new variable to pass old data

                newMovie.MovieName = oldMovie.Movie.MovieName;
                newMovie.MovieIMG = oldMovie.Movie.MovieIMG;
                newMovie.Description = oldMovie.Movie.Description;          //passing old data to database
                newMovie.DirectorID = oldMovie.Movie.DirectorID;
 
                db.Entry(newMovie).State = EntityState.Modified;            //modifying and saving changes
                db.SaveChanges();   
                return RedirectToAction("Movie", "Profile");  // movie profile, new { id = newMovie.MovieID }
            }
            var director = db.Directors.ToList();
            oldMovie.Directors = director;
            return View("Movie",oldMovie);
        }

        public ActionResult DeleteMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(a => a.MovieID == id);
            foreach (var item in db.Movies)
                         db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Movie", "Profile");            
        }

       public ActionResult MovietoActorDelete(int idActor , int idMovie)
        {
           var  movieActor = db.MovieActors.SingleOrDefault(model => model.MovieID == idMovie && model.ActorID == idActor);
            db.MovieActors.Remove(movieActor); 
            db.SaveChanges();
            return RedirectToAction("Movie", "Profile");
        }



    }
}


