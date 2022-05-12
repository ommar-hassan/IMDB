﻿using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using IMDB.ViewModels;
using System.Data.Entity;


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
            var actor = db.Actors.ToList();

            MovieCreationViewModel movieDirectorsViewModel = new MovieCreationViewModel
            {
                Directors = director,
                Actors = actor
            };

            return View(movieDirectorsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMovie(HttpPostedFileBase movieImage, MovieCreationViewModel movieDirectorsViewModel)
        {


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

            var actor = movieDirectorsViewModel.MovieActors;


            db.MovieActors.Add(movieDirectorsViewModel.MovieActors);
            //db.MovieActors.Add(movieDirectorsViewModel.Movie.MovieID);
            db.SaveChanges();

            return RedirectToAction("NewMovie"); // After create go to NewMovie
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewDirector()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewDirector(Director director) {

            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("NewDirector");
            }

            return View("NewDirector");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewActor()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewActor(Actor Actor)
        {

            if (ModelState.IsValid)
            {
                db.Actors.Add(Actor);
                db.SaveChanges();
                return RedirectToAction("NewActor");
            }

            return View("NewActor");
        }

        // update Actor

        [HttpGet]
        public ActionResult ActorsEdit(int? id)
        {
            if (id != null)
            {
                var actor = db.Actors.SingleOrDefault(a => a.ActorID == id); 
                if (actor == null)      //checking integirty  
                {
                    return HttpNotFound(); 
                }
                Actor ActorData = new Actor         // passing required Actor Data for the update
                {
                    ActorID = actor.ActorID,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Description = actor.Description,
                    Age = actor.Age
                    
                };
                Session["ActorID"] = ActorData.ActorID;
                  return View(ActorData);
            }

            else
            {
                return RedirectToAction("ActorList");
            }
        }

       [HttpPost]
        public ActionResult ActorsEdit(Actor oldActor)
        {

            if (ModelState.IsValid)
            {
                Actor newActor = new Actor();
                newActor.ActorID = (int)Session["ActorID"];
                 newActor = db.Actors.SingleOrDefault(a => a.ActorID == newActor.ActorID);

                newActor.FirstName = oldActor.FirstName;
                newActor.LastName = oldActor.LastName;
                newActor.Description = oldActor.Description;
                newActor.Age = oldActor.Age;
               // actorView.ActorIMG = tempActor.ActorIMG;

                db.Entry(newActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ActorProfile", "View", new { id = newActor.ActorID });
            }

            return View();
        }
        
        public ActionResult DeleteActor(int id)
        {
            var actor = db.Actors.SingleOrDefault(a => a.ActorID == id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("ActorList","Profile");
        }

        [HttpGet]
        public ActionResult DirectorsEdit(int? id)
        {
            if (id != null)
            {
                var director = db.Directors.SingleOrDefault(a => a.DirectorID == id);
                if (director == null)      //checking integirty  
                {
                    return HttpNotFound();
                }
                Director directorData = new Director         // passing required Actor Data for the update
                {
                    DirectorID = director.DirectorID,
                    FirstName = director.FirstName,
                    LastName = director.LastName,
                    Description = director.Description,
                    Age = director.Age

                };
                Session["DirectorID"] = directorData.DirectorID;
                return View(directorData);
            }

            else
            {
                return RedirectToAction("DirectorList");
            }
        }

        [HttpPost]
        public ActionResult DirectorssEdit(Director oldDirector)
        {

            if (ModelState.IsValid)
            {
                Director newDirector = new Director();
                newDirector.DirectorID = (int)Session["DirectorID"];
                newDirector = db.Directors.SingleOrDefault(a => a.DirectorID == newDirector.DirectorID);

                newDirector.FirstName = oldDirector.FirstName;
                newDirector.LastName = oldDirector.LastName;
                newDirector.Description = oldDirector.Description;
                newDirector.Age = oldDirector.Age;
                // actorView.ActorIMG = tempActor.ActorIMG;

                db.Entry(newDirector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DirectorProfile", "View", new { id = newDirector.DirectorID });
            }

            return View();
        }
    }
 

 }


