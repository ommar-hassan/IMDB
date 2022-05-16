using IMDB.Models;
using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class ViewController : Controller
    {
        private DBContext _context = new DBContext();
        private readonly int userID = 8;  // random user to be replaced later

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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult MovieProfile(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieID == id);
            if (movie == null)
                return HttpNotFound();

            Session["MovieId"] = id;
            var movieActors = _context.MovieActors.ToList().Where(model => model.MovieID == id);
            var comments = _context.Comments.Where(model => model.MovieID == id);
            var director = movie.Director;
            var rateCount = _context.Likes.Where(model => model.LikeValue == true && model.MovieID == id);
            MovieProfileViewModel profile = new MovieProfileViewModel()
            {
                Movie = movie,
                MovieActor = movieActors,
                Director = director,
                Comments = comments,
                Counter = rateCount.Count()
            };
            
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieProfile(MovieProfileViewModel profile,int? liked)
        {
            var movieId = Int32.Parse(Session["MovieId"].ToString());
            var alreadyLiked = _context.Likes.SingleOrDefault(model => model.UserID == userID && model.MovieID == movieId);

            if (liked != null)
            {
                Boolean likeValue = false;
                if (liked == 1)
                {
                    likeValue = true;
                }
                if (alreadyLiked == null)
                {
                    Like like = new Like() {
                    MovieID = movieId,
                    UserID = userID,
                    LikeValue = likeValue
                    };
                    _context.Likes.Add(like);
                }
                else
                {
                    Like like = _context.Likes.SingleOrDefault(model => model.UserID == userID && model.MovieID == movieId); // to get Like ID for update

                    like.MovieID = movieId;
                    like.UserID = userID;
                    like.LikeValue = likeValue;
                };                    
            }

            if (profile.Comment != null)
            {
                profile.Comment.MovieID = movieId;
                profile.Comment.UserID = userID;
                _context.Comments.Add(profile.Comment);
                
            }
            _context.SaveChanges();
            return RedirectToAction("MovieProfile");
        }
    }
}