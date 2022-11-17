using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class BookingAdditionalService
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int AdditionalServiceId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }

        public AdditionalService AdditionalService { get; set; }
        public Booking Booking { get; set; }
    }
}
