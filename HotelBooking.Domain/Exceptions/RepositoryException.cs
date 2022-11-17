using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Domain.Exceptions
{
    public class RepositoryException : Exception
    {
        public string MessageError { get; set; }
        public RepositoryException(string messageError)
        {
            MessageError = messageError;
        }
    }
}
