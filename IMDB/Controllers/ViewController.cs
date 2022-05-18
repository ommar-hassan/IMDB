using IMDB.Classes;
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
        private DBContext db = new DBContext();
        Find search = new Find();
         // random user to be replaced later

        // GET: View
        public ActionResult ActorProfile(int id)
        {
            MovieActor particpations = new MovieActor();
            var actorView = search.FindActorByID(id);
            var actor_movie = search.FindMovieActorsByID(id).ToList();
            Actor_Movie actorProfile = new Actor_Movie
            {
                Actor = actorView,
                MovieActors = actor_movie

            };
            if (actorProfile == null)
                return HttpNotFound();

            return View(actorProfile);
        }


        public ActionResult DirectorProfile(int id)
        {

            var directorView = search.FindDirectorByID(id);
            var director_movie = search.FindMovieDirectorsByID(id).ToList();
            Director_Movie directorProfile = new Director_Movie
            {
                Director = directorView,
                Movies = director_movie

            };
            if (directorProfile == null)
                return HttpNotFound();

            return View(directorProfile);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult MovieProfile(int id)
        {
            var movie = search.FindMovieByID(id);
            if (movie == null)
                return HttpNotFound();

            Session["MovieId"] = id;
            var userName = " ";
            if (Session["UserName"] != null)
            {
                userName = Session["UserName"].ToString();
            }
            var movieActors = db.MovieActors.ToList().Where(model => model.MovieID == id);
            var comments = db.Comments.Where(model => model.MovieID == id);
            var director = movie.Director;
            var rateCount = db.Likes.Where(model => model.LikeValue == true && model.MovieID == id);
            MovieProfileViewModel profile = new MovieProfileViewModel()
            {
                Movie = movie,
                MovieActor = movieActors,
                Director = director,
                Comments = comments,
                UserName = userName,
                Counter = rateCount.Count()
            };
            
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieProfile(MovieProfileViewModel profile,int? liked)
        {
            int userID = (int)Session["UserId"];
            var movieId = Int32.Parse(Session["MovieId"].ToString());
            var alreadyLiked = db.Likes.SingleOrDefault(model => model.UserID == userID && model.MovieID == movieId);

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
                    db.Likes.Add(like);
                }
                else
                {
                    Like like = db.Likes.SingleOrDefault(model => model.UserID == userID && model.MovieID == movieId); // to get Like ID for update

                    like.MovieID = movieId;
                    like.UserID = userID;
                    like.LikeValue = likeValue;
                };
            }

            if (profile.Comment != null)
            {
                profile.Comment.MovieID = movieId;
                profile.Comment.UserID = userID;
                db.Comments.Add(profile.Comment);
                
            }
            db.SaveChanges();
            return RedirectToAction("MovieProfile");
        }
    }
}