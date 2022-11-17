using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class PersonImage
    {
        public int PersonId { get; set; }
        public byte[] Image { get; set; }

        public PersonInfo Person { get; set; }
    }
}
