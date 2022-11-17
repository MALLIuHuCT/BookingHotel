using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class AdditionalService
    {
        public AdditionalService()
        {
            BookingAdditionalService = new HashSet<BookingAdditionalService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int? ServiceTypeId { get; set; }

        public virtual AdditionalServiceType ServiceType { get; set; }
        public virtual ICollection<BookingAdditionalService> BookingAdditionalService { get; set; }
    }
}
