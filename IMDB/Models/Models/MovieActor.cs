using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class MovieActor
    {
        [Key]
        public int ID { get; set; }

        public virtual Movie Movie { get; set; }

        [ForeignKey("Movie")]
        public int? MovieID { get; set; }

        public virtual Actor Actor { get; set; }

        [ForeignKey("Actor")]
        public int? ActorID { get; set; }
    }
}