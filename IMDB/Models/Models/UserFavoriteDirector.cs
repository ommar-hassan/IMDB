using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class UserFavoriteDirector
    {
        [Key]
        public int ID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        public virtual Director Director { get; set; }

        [ForeignKey("Director")]
        public int? DirectorID { get; set; }
    }
}