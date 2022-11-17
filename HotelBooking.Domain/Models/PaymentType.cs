using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.Domain.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Cheques = new HashSet<Cheque>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Cheque> Cheques { get; set; }
    }
}
