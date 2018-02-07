﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Web.Entities
{
    public class Magazine : TEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int YearOfPublishing { get; set; }
    }
}