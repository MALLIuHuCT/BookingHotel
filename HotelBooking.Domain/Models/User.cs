using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public PersonInfo IdNavigation { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
