using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelClassId { get; set; }
        public byte Stars { get; set; }
        public int StreetId { get; set; }
        public byte HomeNumber { get; set; }
        public int? ImageId { get; set; }

        public HotelClassification HotelClass { get; set; }
        public HotelImage Image { get; set; }
        public Street Street { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
