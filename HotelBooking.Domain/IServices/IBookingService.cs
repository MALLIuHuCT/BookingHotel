using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IServices
{
    public interface IBookingService
    {
        Task<Booking[]> GetAll();
        Task<Booking[]> GetAllWithInclude();
        Task<Booking> GetById(int bookingId);
        Task<Booking> GetByIdWithInclude(int bookingId);
        Task<Booking> Add(Booking booking);
        void Update(Booking booking);
        void RemoveById(int bookingId);
    }
}
