using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Age")]
        public String Age { get; set; }
    }
}