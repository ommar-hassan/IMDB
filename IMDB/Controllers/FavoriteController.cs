using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class FavoriteController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Favorite

        [HttpGet]
        [AllowAnonymous]
        public ActionResult FavoriteActor()
        {
            var actors = db.Actors.ToList();

            FavoriteActor favActor = new FavoriteActor()
            {
                Actors = actors,
            };

            return View(favActor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FavoriteActor(FavoriteActor favActor)
        {
            int userId = (int)Session["UserId"];
            if (ModelState.IsValid)
            {
                
                favActor.User.UserID = userId;
                db.UserFavoriteActors.Add(favActor.UserFavoriteActor);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            var actors = db.Actors.ToList();
            favActor.Actors = actors;
            return View(favActor);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult FavoriteDirector()
        {
            var directors = db.Directors.ToList();

            FavoriteDirector favDirector = new FavoriteDirector()
            {
                Directors = directors,
            };

            return View(favDirector);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FavoriteDirector(FavoriteDirector favDirector)
        {
            int userId = (int)Session["UserId"];
            if (ModelState.IsValid)
            {

                favDirector.User.UserID = userId;
                db.UserFavoriteDirectors.Add(favDirector.UserFavoriteDirector);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            var directors = db.Directors.ToList();
            favDirector.Directors = directors;
            return View(favDirector);
        }

    }
}