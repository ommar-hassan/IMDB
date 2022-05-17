using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModels
{
    public class FavoriteDirector
    {
        public IEnumerable<Director> Directors { get; set; }

        public UserFavoriteDirector UserFavoriteDirector { get; set; }

        public User User { get; set; }
    }
}