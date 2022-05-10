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

        [Required(ErrorMessage = "*" )]
        [Display(Name = "Movie Name")]
        public String MovieName { get; set; }

        [Display(Name = "Movie Image")]
        public Byte[] MovieIMG { get; set; }
        
        public virtual Director Director { get; set; }

        [Required(ErrorMessage = "*")]
        [ForeignKey("Director")]
        [Display(Name = "Movie Director")]
        public int? DirectorID { get; set; }
    }
}