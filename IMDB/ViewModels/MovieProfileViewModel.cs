using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class MovieProfileViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Actor> Actors { get; set; }

        public IEnumerable<MovieActor> MovieActor { get; set; }

        public Director Director { get; set; }

        public Comment Comment { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public User User { get; set; }

        public Like Like { get; set; }

        public IEnumerable<Like> Likes { get; set; }

        public int Counter { get; set; }

        public string UserName { get; set; }
    }
}