﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class MovieDirectorsViewModel 
    {
        public Movie Movie { get; set; }

        public IEnumerable<Director> Directors { get; set; }

        public MovieActor MovieActors { get; set; }

    }
}