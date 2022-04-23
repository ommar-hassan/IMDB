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

        public Movie MovieID { get; set; }

        public User UserID { get; set; }
    }
}