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

            MovieDirectorsViewModel movieDirectorsViewModel = new MovieDirectorsViewModel
            {
                Directors = director
                
            };

            return View(movieDirectorsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMovie(HttpPostedFileBase movieImage, MovieDirectorsViewModel movieDirectorsViewModel)
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

            return RedirectToAction("NewMovie"); // After create go to NewMovie
        }

    }
}