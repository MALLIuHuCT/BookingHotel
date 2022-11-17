using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Domain.Exceptions
{
    public class ServiceException : Exception
    {
        public string MessageError { get; set; }
        public ServiceException(string messageError)
        {
            MessageError = messageError;
        }
    }
}
