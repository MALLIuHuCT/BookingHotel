using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class PersonInfo
    {
        public PersonInfo()
        {
            BookingAssignedPerson = new HashSet<BookingAssignedPerson>();
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

        public virtual PersonImage PersonImage { get; set; }
        public virtual ICollection<BookingAssignedPerson> BookingAssignedPerson { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
