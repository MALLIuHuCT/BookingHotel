using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class RoomImage
    {
        public RoomImage()
        {
            RoomInfos = new HashSet<RoomInfo>();
        }

        public int Id { get; set; }
        public byte[] Image { get; set; }

        public ICollection<RoomInfo> RoomInfos { get; set; }
    }
}
