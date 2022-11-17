using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class AdditionalServiceType
    {
        public AdditionalServiceType()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
