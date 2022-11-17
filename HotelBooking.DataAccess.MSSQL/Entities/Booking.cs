using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            BookingAdditionalService = new HashSet<BookingAdditionalService>();
            BookingAssignedPerson = new HashSet<BookingAssignedPerson>();
            Cheque = new HashSet<Cheque>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BookingStatusId { get; set; }

        public virtual BookingStatus BookingStatus { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<BookingAdditionalService> BookingAdditionalService { get; set; }
        public virtual ICollection<BookingAssignedPerson> BookingAssignedPerson { get; set; }
        public virtual ICollection<Cheque> Cheque { get; set; }
    }
}
