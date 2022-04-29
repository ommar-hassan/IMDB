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

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Password { get; set; }

        public Byte[] ProfileIMG { get; set; }

        public int RoleID { get; set; }
    }
}