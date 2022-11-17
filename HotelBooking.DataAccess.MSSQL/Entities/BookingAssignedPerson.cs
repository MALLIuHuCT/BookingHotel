using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class BookingAssignedPerson
    {
        public int BookingId { get; set; }
        public int PersonId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual PersonInfo Person { get; set; }
    }
}
