using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelClassId { get; set; }
        public byte Stars { get; set; }
        public int StreetId { get; set; }
        public byte HomeNumber { get; set; }
        public int? ImageId { get; set; }

        public virtual HotelClassification HotelClass { get; set; }
        public virtual HotelImage Image { get; set; }
        public virtual Street Street { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
