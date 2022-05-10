using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public String Content { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey("Movie")]
        public int? MovieID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }
    }
}