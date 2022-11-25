using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Booking.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}