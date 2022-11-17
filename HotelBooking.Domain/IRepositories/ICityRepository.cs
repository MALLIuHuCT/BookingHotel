using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IRepositories
{
    public interface ICityRepository
    {
        Task<City[]> GetAll();
        Task<City> Get(int cityId);
        City Add(City city);
        City[] Add(City[] city);
        void Update(City city);
        void Update(City[] cities);
        void Remove(City city);
        void Remove(City[] cities);
    }
}
