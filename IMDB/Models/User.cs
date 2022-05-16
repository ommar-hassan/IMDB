using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class User
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "ID")]
        public int UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Profile Image")]
        public Byte[] ProfileIMG { get; set; }


        [Display(Name = "RoleID")]
        public int RoleID { get; set; }

    }
}