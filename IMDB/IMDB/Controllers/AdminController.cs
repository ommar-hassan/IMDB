using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult NewMovie()
        {
            Movie admin = new Movie()
            {
                MovieName = "DjangoUnchained"
            };

            DBContext db = new DBContext();
            var q = db.Actors.ToList();

            return View(admin);
        }
        
    }
    
}