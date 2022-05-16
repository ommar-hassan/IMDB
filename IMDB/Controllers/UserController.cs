using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using System.Net;
using System.IO;

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
        public ActionResult Registration(HttpPostedFileBase userImage, User User)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("home");
            }
            if (userImage != null)
            {
                MemoryStream target = new MemoryStream();
                userImage.InputStream.CopyTo(target);
                byte[] userImageByteArray = target.ToArray();
                User.ProfileIMG = userImageByteArray;
            }
            return View("Registration");
        }

        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var Details = (from pepole in db.Users
                               where pepole.Email == user.Email &&
                                 pepole.Password == user.Password
                               select new
                               {
                                   user.UserID,
                                   user.Email
                               }).ToList();
                if (Details.FirstOrDefault() != null)
                {
                    Session["ID"] = Details.FirstOrDefault().UserID;
                    Session["Email"] = Details.FirstOrDefault().Email;
                    return RedirectToAction("home");
                }
            }
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,FirstName,LastName,Password,ProfileImage,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
                  
   
