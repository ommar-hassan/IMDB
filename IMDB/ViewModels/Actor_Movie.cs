using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class Actor_Movie
    {
        public Actor Actor { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<MovieActor> MovieActors { get; set; }

    }
}