using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Street
    {
        public Street()
        {
            Hotel = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Hotel> Hotel { get; set; }
    }
}
