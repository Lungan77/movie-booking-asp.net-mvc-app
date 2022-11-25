using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Booking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Dates Dates { get; set; }
        public int DatesId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}