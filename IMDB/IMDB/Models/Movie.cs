using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        public String MovieName { get; set; }

        public Byte[] MovieIMG { get; set; }

        public Director DirectorID { get; set; }
    }
}