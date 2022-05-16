using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using System.Data.Entity;

namespace IMDB.Controllers
{
    public class UserController : Controller
    {
        // Registration
        private DBContext db = new DBContext();


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User User)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("Registration");
            }
            return View("Registration");
        }


    }
}