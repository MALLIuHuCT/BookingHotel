using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class Street
    {
        public Street()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
