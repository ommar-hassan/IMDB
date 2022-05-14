using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Director Image")]
        public Byte[] DirectorIMG { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Age")]
        [Range(3, 100, ErrorMessage = "The Director should be 3-100 years old")]
        public String Age { get; set; }


    }
}