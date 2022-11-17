using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Cheque = new HashSet<Cheque>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Cheque> Cheque { get; set; }
    }
}
