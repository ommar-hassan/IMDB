using IMDB.ViewModels;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext db = new DBContext();
        // GET: Home
        public ActionResult Home()
        {
            var userName = " ";
            if (Session["UserName"] != null)
            {
            userName = Session["UserName"].ToString();
            }
            var directors = db.Directors.ToList();
            var actors = db.Actors.ToList();
            var movies = db.Movies.ToList();
            HomeViewModel data = new HomeViewModel()
            {
                Directors = directors,
                Actors = actors,
                Movies = movies,
                UserName = userName
            };
            return View(data);
        }
    }
}