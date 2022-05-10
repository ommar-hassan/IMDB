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

            if (movieImage == null)
            {
                return HttpNotFound();
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
        public ActionResult NewDirector(HttpPostedFileBase directorImage, Director director) {

            if (directorImage == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                MemoryStream target = new MemoryStream();
                directorImage.InputStream.CopyTo(target);
                byte[] directorImageByteArray = target.ToArray();
                director.DirectorIMG = directorImageByteArray;


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
        public ActionResult NewActor(HttpPostedFileBase actorImage, Actor actor)
        {
            if (actorImage == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                MemoryStream target = new MemoryStream();
                actorImage.InputStream.CopyTo(target);
                byte[] actorImageByteArray = target.ToArray();
                actor.ActorIMG = actorImageByteArray;

                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("NewActor");
            }

            return View("NewActor");
        }

    }
}