using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Actor
    {
        internal List<Actor> actorData;

        [Key]
        public int ActorID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "FirstName")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "LastName")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Age")]
        public String Age { get; set; }

        public Byte[] ActorIMG { get; set; }
    }
}