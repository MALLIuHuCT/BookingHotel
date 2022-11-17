using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class HotelImage
    {
        public HotelImage()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public byte[] Image { get; set; }

        public ICollection<Hotel> Hotels { get; set; }
    }
}
