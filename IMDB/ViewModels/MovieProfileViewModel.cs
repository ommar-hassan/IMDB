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
    }
}