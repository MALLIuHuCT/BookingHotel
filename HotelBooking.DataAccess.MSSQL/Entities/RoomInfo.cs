using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
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

        public virtual RoomImage Image { get; set; }
        public virtual Room Room { get; set; }
    }
}
