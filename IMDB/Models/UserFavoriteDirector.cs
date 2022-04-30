﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class UserFavoriteDirector
    {
        [Key]
        public int ID { get; set; }

        public virtual User UserID { get; set; }

        public virtual Director DirectorID { get; set; }
    }
}