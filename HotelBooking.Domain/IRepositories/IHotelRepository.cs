using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IRepositories
{
    public interface IHotelRepository
    {
        Task<Hotel[]> GetAll();
        Task<Hotel[]> GetAllWithInclude();
        Task<Hotel> GetById(int hotelId);
        Task<Hotel> GetByIdWithInclude(int hotelId);
        Hotel Add(Hotel hotel);
        void Update(Hotel hotel);
        void Remove(int hotelId);
    }
}