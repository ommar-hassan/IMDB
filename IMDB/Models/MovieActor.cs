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
        public virtual Movie Movie { get; set; }

        [Required(ErrorMessage = "*")]
        [ForeignKey("Movie")]
        public int MovieID { get; set; }

        public virtual Actor Actor { get; set; }

        [Required(ErrorMessage = "*")]
        [ForeignKey("Actor")]
        public int ActorID { get; set; }
    }
}