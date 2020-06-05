using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Productora.Web.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string AlbumName { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(250)]
        public string AlbumDescription { get; set; }
        [Display(Name = "Lanzamiento")]
        public DateTime AlbumRelease { get; set; }
        [Display(Name = "Carátula")]
        public byte[] AlbumCover { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}