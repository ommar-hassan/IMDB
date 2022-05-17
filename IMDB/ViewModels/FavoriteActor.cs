using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class FavoriteActor
    {
        public IEnumerable<Actor> Actors { get; set; }

        public UserFavoriteActor UserFavoriteActor { get; set; }

        public User User { get; set; }
    }
}