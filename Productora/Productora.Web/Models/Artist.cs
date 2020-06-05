using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Productora.Web.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Artístico")]
        [MaxLength(25)]
        public string StageName { get; set; }
        [Display(Name = "Correo Electrónico")]
        [Required]
        [MaxLength(45)]
        public string Email { get; set; }
        public byte[] artimg { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}