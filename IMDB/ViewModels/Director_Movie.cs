using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;
namespace IMDB.ViewModels
{
    public class Director_Movie
    {
        public  Director Director { get; set; }

        public IEnumerable<Movie> Movies { get; set; }

    }
}