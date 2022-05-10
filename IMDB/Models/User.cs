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
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID required")]
        [Display(Name = "ID")]
        public int UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "email required")]
        [Display(Name = "Email")]
        public String Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        //[MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        [Display(Name = "Password")]
        public String Password { get; set; }


        public Byte[] ProfileIMG { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "1 for admin   0 for user")]
        [Display(Name = "RoleID")]
        public int RoleID { get; set; }


    }
}