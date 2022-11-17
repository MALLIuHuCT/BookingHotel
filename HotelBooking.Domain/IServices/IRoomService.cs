using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IServices
{
    public interface IRoomService
    {
        Task<Room[]> GetAll();
        Task<Room[]> GetAllWithInclude();
        Task<Room[]> GetAllByHotelId(int hotelId);
        Task<Room[]> GetAllWithIncludeByHotelId(int hotelId);
        Task<Room> GetById(int roomId);
        Task<Room> GetByIdWithInclude(int roomId);
        Room Add(Room room);
        void Update(Room room);
        void RemoveById(int roomId);
    }
}
