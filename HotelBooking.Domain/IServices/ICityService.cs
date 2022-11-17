using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IServices
{
    public interface ICityService
    {
        Task<City[]> GetAll();
        Task<City> Get(int cityId);
        void Remove(City city);
        void Remove(City[] citys);
        void Update(City city);
        void Update(City[] citys);
    }
}
