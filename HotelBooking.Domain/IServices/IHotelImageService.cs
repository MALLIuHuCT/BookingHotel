using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IServices
{
    public interface IHotelImageService
    {
        Task<HotelImage[]> GetAll();
        Task<HotelImage> GetById(int hotelId);
        public HotelImage Add(HotelImage hotelImage);
        void Update(HotelImage hotel);
        void RemoveById(int hotelId);
    }
}
