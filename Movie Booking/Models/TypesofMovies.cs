using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Booking.Models
{
    public class TypesofMovies
    {
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public string Type { get; set; }
    }
}