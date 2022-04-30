using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class UserFavoriteActor
    {
        [Key]
        public int ID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        public virtual Actor Actor { get; set; }

        [ForeignKey("Actor")]
        public int? ActorID { get; set; }
    }
}