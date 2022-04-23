using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Like
    {
        [Key]
        public int ID { get; set; }

        public User UserID { get; set; }

        public Movie MovieID { get; set; }
    }
}