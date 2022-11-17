using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IRepositories
{
    public interface IHotelImageRepository
    {
        Task<HotelImage[]> GetAll();
        Task<HotelImage> GetById(int hotelImageId);
        HotelImage Add(HotelImage hotelImage);
        void Update(HotelImage hotelImage);
        void Remove(int hotelImageId);
    }
}
