using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingAdditionalServices = new HashSet<BookingAdditionalService>();
            BookingAssignedPeople = new HashSet<BookingAssignedPerson>();
            Cheques = new HashSet<Cheque>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BookingStatusId { get; set; }

        public BookingStatus BookingStatus { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public ICollection<BookingAdditionalService> BookingAdditionalServices { get; set; }
        public ICollection<BookingAssignedPerson> BookingAssignedPeople { get; set; }
        public ICollection<Cheque> Cheques { get; set; }
    }
}
