using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Person
    {
        public int IdInt { get; set; }
        public string IdGuid { get; set; }

        public virtual AspNetUsers IdGu { get; set; }
        public virtual PersonInfo IdIntNavigation { get; set; }
    }
}
