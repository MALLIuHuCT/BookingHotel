using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public byte Floor { get; set; }
        public short Number { get; set; }
        public int RoomTypeId { get; set; }
        public int? SpecialCost { get; set; }

        public RoomType RoomType { get; set; }
        public RoomInfo RoomInfo { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
