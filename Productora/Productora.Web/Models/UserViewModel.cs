using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Productora.Web.Models
{
    public class UserViewModel
    {
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Display(Name = "Nombre Artístico")]
        [MaxLength(25)]
        public string StageName { get; set; }
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public string artimg { get; set; }
    }
}