using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class Cheque
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime PaymentDate { get; set; }
        public TimeSpan PaymentTime { get; set; }
        public int Price { get; set; }

        public Booking Booking { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
