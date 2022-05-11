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

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Actor Image")]
        public Byte[] ActorIMG { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Age")]
        [Range(3,100,ErrorMessage ="The Actor should be 3-100 years old")]
        public String Age { get; set; }

        public ICollection<MovieActor> MovieActor { get; set; }
    }
}