using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class BookingAssignedPerson
    {
        public int BookingId { get; set; }
        public int PersonId { get; set; }

        public Booking Booking { get; set; }
        public PersonInfo Person { get; set; }
    }
}
