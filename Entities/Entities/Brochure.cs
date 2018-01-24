﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Web.Entities
{
    public class Brochure
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeOfCover { get; set; }
        [Required]
        public int NumberOfPages { get; set; }
    }
}