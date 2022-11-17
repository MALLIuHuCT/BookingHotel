using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class RoomInfo
    {
        public int RoomId { get; set; }
        public byte RoomsAmount { get; set; }
        public decimal? SquareMeters { get; set; }
        public bool Kitchen { get; set; }
        public bool Bathroom { get; set; }
        public bool Conditioner { get; set; }
        public bool Balcony { get; set; }
        public bool Tv { get; set; }
        public bool WashingMachine { get; set; }
        public bool SoundIsolation { get; set; }
        public int? ImageId { get; set; }

        public RoomImage Image { get; set; }
        public Room Room { get; set; }
    }
}
