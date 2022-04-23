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
        public int UserID { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public int RoleID { get; set; }
    }
}