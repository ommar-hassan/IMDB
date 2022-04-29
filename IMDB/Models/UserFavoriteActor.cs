using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class UserFavoriteActor
    {
        [Key]
        public int ID { get; set; }

        public User UserID { get; set; }

        public Actor ActorID { get; set; }
    }
}