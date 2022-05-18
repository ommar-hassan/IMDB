using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using System.Net;
using System.IO;
using IMDB.Classes;

namespace IMDB.Controllers
{
    public class UserController : Controller
    {
        // Registration
        private DBContext db = new DBContext();
        readonly int adminRole = 0;
        readonly int userRole = 1;
        readonly Admin admin = new Admin();

        SetData set = new SetData();

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
                if (userImage != null)
                {
                    set.SetProfileImage(userImage, User);
                }
                User.RoleID = adminRole;          //   1  for  User  >>  0  for  Admin
                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            
            return View("Registration");
        }

        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    User validuser = db.Users.FirstOrDefault(User => User.Email.ToLower() == login.Email.ToLower() && User.Password == login.Password);
                    if (validuser != null)
                    {
                        Session["UserId"] = validuser.UserID;
                        Session["UserName"] = validuser.FirstName + " " + validuser.LastName;
                        Session["UserImg"] = validuser.ProfileIMG;
                        if(validuser.RoleID == userRole)  //      Admin
                        {
                            return RedirectToAction("ActorList", "Profile");
                        }
                        else {                           //       User
                            return RedirectToAction("Home", "Home");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            catch (NullReferenceException ex)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
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
                admin.UpdateUserToDatabase(user);
                return RedirectToAction("Home");
            }
            return View(user);
        }

    }
}
