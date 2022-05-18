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
using IMDB.Classes;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    public class AdminController : Controller
    {
        private DBContext db = new DBContext();
        Find search = new Find();
        GetData get = new GetData();
        SetData set = new SetData();
        Admin admin = new Admin();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewMovie()
        {
            MovieCreationViewModel movieDirectorsViewModel = set.SetDirectors();

            return View(movieDirectorsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMovie(HttpPostedFileBase movieImage, MovieCreationViewModel movieDirectorsViewModel)
        {

            if (!ModelState.IsValid)
            {
                movieDirectorsViewModel.Directors = get.GetDirectors();
                return View("NewMovie", movieDirectorsViewModel);
            }

            if (movieImage != null)
            {
                set.SetMovieImage(movieImage, movieDirectorsViewModel);
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
                    set.SetDirectorImage(directorImage, director);
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
                    set.SetActorImage(actorImage, actor);
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
            AssignsViewModel movieAndActor = get.GetMovieActors();

            return View(movieAndActor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieToActor(AssignsViewModel movieAndActor)
        {

            if (!ModelState.IsValid)
            {
                movieAndActor.Actors = get.GetActors();

                movieAndActor.Movies = get.GetMovies();

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
                Actor actor = search.FindActorByID(id);
                if (actor == null)      //checking integirty  
                {
                    return HttpNotFound();
                }
                Actor ActorData = set.SetActor(actor); // passing required Actor Data for the update
                Session["ActorID"] = ActorData.ActorID;
                return View(ActorData);
            }

            else
            {
                return RedirectToAction("ActorList");
            }
        }

        [HttpPost]
        public ActionResult ActorsEdit(Actor oldActor, HttpPostedFileBase ActorImage)
        {

            if (ModelState.IsValid) //oldImage convertor
            {
                set.SetActorImage(ActorImage, oldActor);

                Actor newActor = new Actor();
                newActor.ActorID = (int)Session["ActorID"];
                newActor = search.FindActorByID(newActor.ActorID);
                admin.CopyActorData(oldActor, newActor);

                admin.UpdateActorToDatabase(newActor);
                return RedirectToAction("ActorProfile", "View", new { id = newActor.ActorID });
            }

            return View();
        }

        public ActionResult DeleteActor(int id)
        {
            Actor actor = search.FindActorByID(id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("ActorList", "Profile");
        }

        [HttpGet]
        public ActionResult DirectorsEdit(int? id)
        {
            if (id != null)
            {
                Director director = search.FindDirectorByID(id);
                if (director == null)      //checking integirty  
                {
                    return HttpNotFound();
                }
                Director directorData = set.SetDirector(director);
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
                //oldImage convertor
                set.SetDirectorImage(image, oldDirector);

                Director newDirector = new Director();
                newDirector.DirectorID = (int)Session["DirectorID"];
                newDirector = search.FindDirectorByID(newDirector.DirectorID);
                admin.CopyDirectorData(oldDirector, newDirector);
                admin.UpdateDirectorToDatabase(newDirector);
                return RedirectToAction("DirectorProfile", "View", new { id = newDirector.DirectorID });
            }

            return View();
        }

        public ActionResult DeleteDriector(int id)
        {
            var director = search.FindDirectorByID(id);
            admin.DeleteDirectorFromMovies(id);
            db.Directors.Remove(director);
            db.SaveChanges();
            return RedirectToAction("DirectorList", "Profile");
        }

        [HttpGet]
        public ActionResult MovieEdit(int? id)
        {
            if (id != null)
            {
                Movie movie = search.FindMovieByID(id);
                if (movie == null)      //checking integirty  
                {
                    return HttpNotFound();
                }

                // passing required Actor Data for the update
                MovieCreationViewModel movieData = get.GetMovieDirectors(movie);

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
            return View("Movie", oldMovie);
        }

        public ActionResult DeleteMovie(int id)
        {
            admin.DeleteMovieFromDatabase(id);
            return RedirectToAction("Movie", "Profile");
        }

        public ActionResult MovietoActorDelete(int idActor , int idMovie)
        {
            MovieActor movieActor = search.FindMovieActorByID(idMovie, idActor);
            db.MovieActors.Remove(movieActor);
            db.SaveChanges();
            return RedirectToAction("Movie", "Profile");
        }
    }
}
