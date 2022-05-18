using IMDB.ViewModels;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Classes;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext db = new DBContext();
        GetData get = new GetData();
        SetData set = new SetData();
        // GET: Home
        public ActionResult Home()
        {
            var userName = " ";
            if (Session["UserName"] != null)
            {
                userName = Session["UserName"].ToString();
            }
            var directors = get.GetDirectors();
            var actors = get.GetActors();
            var movies = get.GetMovies();
            HomeViewModel data = set.SetHomePageData(userName, directors, actors, movies);
            return View(data);
        }

        
    }
}