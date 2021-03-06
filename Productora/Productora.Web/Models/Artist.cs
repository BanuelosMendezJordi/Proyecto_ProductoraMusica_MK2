﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Productora.Web.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Display(Name ="Nombre")]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Display(Name = "Nombre Artístico")]
        [MaxLength(25)]
        public string StageName { get; set; }
        [Display(Name ="Imagen")]
        public string artimg { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}