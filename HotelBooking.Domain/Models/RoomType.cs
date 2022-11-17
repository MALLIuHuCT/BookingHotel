using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
