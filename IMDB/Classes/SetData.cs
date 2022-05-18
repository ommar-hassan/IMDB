using IMDB.Models;
using IMDB.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IMDB.Classes
{
    public class SetData
    {
        private readonly DBContext db = new DBContext();

        GetData get = new GetData();

        /// <summary>
        /// Directors setter in view model
        /// </summary>
        /// <returns></returns>
        public MovieCreationViewModel SetDirectors()
        {
            MovieCreationViewModel movieDirectorsViewModel = new MovieCreationViewModel
            {
                Directors = get.GetDirectors()
            };
            return movieDirectorsViewModel;
        }

        /// <summary>
        /// Movie Image Setter
        /// </summary>
        /// <param name="movieImage"></param>
        /// <param name="movieDirectorsViewModel"></param>
        public void SetMovieImage(HttpPostedFileBase movieImage, MovieCreationViewModel movieDirectorsViewModel)
        {
            
                MemoryStream target = new MemoryStream();
                movieImage.InputStream.CopyTo(target);
                byte[] movieImageByteArray = target.ToArray();
                movieDirectorsViewModel.Movie.MovieIMG = movieImageByteArray;
        }

        /// <summary>
        /// Director Image Setter
        /// </summary>
        /// <param name="directorImage"></param>
        /// <param name="director"></param>
        public void SetDirectorImage(HttpPostedFileBase directorImage, Director director)
        {
            
                MemoryStream target = new MemoryStream();
                directorImage.InputStream.CopyTo(target);
                byte[] directorImageByteArray = target.ToArray();
                director.DirectorIMG = directorImageByteArray;
        }

        /// <summary>
        /// Actor Image Setter
        /// </summary>
        /// <param name="actorImage"></param>
        /// <param name="actor"></param>
        public void SetActorImage(HttpPostedFileBase actorImage, Actor actor)
        {
                MemoryStream target = new MemoryStream();
                actorImage.InputStream.CopyTo(target);
                byte[] actorImageByteArray = target.ToArray();
                actor.ActorIMG = actorImageByteArray;
        }

        /// <summary>
        /// Set Actor
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public Actor SetActor(Actor actor)
        {
            Actor ActorData = new Actor
            {
                ActorID = actor.ActorID,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Description = actor.Description,
                Age = actor.Age

            };
            return ActorData;
        }

        /// <summary>
        /// Set Director
        /// </summary>
        /// <param name="director"></param>
        /// <returns></returns>
        public Director SetDirector(Director director)
        {
            Director directorData = new Director         // passing required Actor Data for the update
            {
                DirectorID = director.DirectorID,
                FirstName = director.FirstName,
                LastName = director.LastName,
                Description = director.Description,
                Age = director.Age
            };
            return directorData;
        }

        /// <summary>
        /// Set all home page Data
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="directors"></param>
        /// <param name="actors"></param>
        /// <param name="movies"></param>
        /// <returns></returns>
        public HomeViewModel SetHomePageData(string userName, List<Director> directors, List<Actor> actors, List<Movie> movies)
        {
            return new HomeViewModel()
            {
                Directors = directors,
                Actors = actors,
                Movies = movies,
                UserName = userName
            };
        }

        /// <summary>
        /// User Image Setter
        /// </summary>
        /// <param name="actorImage"></param>
        /// <param name="actor"></param>
        public void SetProfileImage(HttpPostedFileBase userImage, User User)
        {
            MemoryStream target = new MemoryStream();
            userImage.InputStream.CopyTo(target);
            byte[] userImageByteArray = target.ToArray();
            User.ProfileIMG = userImageByteArray;
        }
    }
}