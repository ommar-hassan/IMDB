using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using IMDB.ViewModels;

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
            var actor = db.Actors.ToList();

            MovieCreationViewModel movieDirectorsViewModel = new MovieCreationViewModel
            {
                Directors = director,
                Actors = actor
            };

            return View(movieDirectorsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMovie(HttpPostedFileBase movieImage, MovieCreationViewModel movieDirectorsViewModel)
        {

            if (movieImage == null)
            {
                return View("error");
            }
            
            
            if (!ModelState.IsValid)
            {
                var director = db.Directors.ToList();
                movieDirectorsViewModel.Directors = director;

                return View("NewMovie",movieDirectorsViewModel);
            }
            MemoryStream target = new MemoryStream();
            movieImage.InputStream.CopyTo(target);
            byte[] movieImageByteArray = target.ToArray();

            movieDirectorsViewModel.Movie.MovieIMG = movieImageByteArray;

            db.Movies.Add(movieDirectorsViewModel.Movie);
            db.SaveChanges();

            var actor = movieDirectorsViewModel.MovieActors;


            db.MovieActors.Add(movieDirectorsViewModel.MovieActors);
            //db.MovieActors.Add(movieDirectorsViewModel.Movie.MovieID);
            db.SaveChanges();

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
        public ActionResult NewDirector(Director director) {

            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
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
        public ActionResult NewActor(Actor Actor)
        {

            if (ModelState.IsValid)
            {
                db.Actors.Add(Actor);
                db.SaveChanges();
                return RedirectToAction("NewActor");
            }

            return View("NewActor");
        }

    }
}