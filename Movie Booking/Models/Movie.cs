using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie_Booking.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        public double Price { get; set; }
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        [Display(Name = "Genre")]
        public TypesofMovies TypesofMovies { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Display(Name = "Genre")]
        public int TypesofMoviesId { get; set; }
        public string Trailer { get; set; }
        [Display(Name = "Movie Image Url")]
        public string ImageURL { get; set; }
        [Display(Name = "Director")]
        public string Director { get; set; }
        [Display(Name = "Writer")]
        public string Writer { get; set; }
        [Display(Name = "Cast")]
        public string Starring { get; set; }
    }
}