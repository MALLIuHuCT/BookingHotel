using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.DataAccess.MSSQL;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DataAccess.MSSQL.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly BookingHotelsContext _context;
        private readonly IMapper _mapper;

        public CityRepository(BookingHotelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<City[]> GetAll()
        {
            var cities = await _context.City
                .AsNoTracking()
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<City[]>(source.Result));
            return cities;
        }

        public async Task<City> Get(int cityId)
        {
            var city = await _context.City
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == cityId)
                .ContinueWith(source => _mapper.Map<City>(source.Result)); ;
            return city;
        }

        public City Add(City city)
        {
            var mappedCity = _mapper.Map<Entities.City>(city);
            _context.City.Add(mappedCity);
            _context.SaveChanges();

            var unmappedHotel = _mapper.Map<City>(mappedCity);
            return unmappedHotel;
        }

        public City[] Add(City[] cities)
        {
            var mappedCities = _mapper.Map<Entities.City[]>(cities);
            _context.City.AddRange(mappedCities);
            _context.SaveChanges();

            var unmappedHotels = _mapper.Map<City[]>(mappedCities);
            return unmappedHotels;
        }

        public void Update(City city)
        {
            var mappedCity = _mapper.Map<Entities.City>(city);
            _context.City.Update(mappedCity);
            _context.SaveChanges();
        }

        public void Update(City[] cities)
        {
            var mappedCities = _mapper.Map<Entities.City[]>(cities);
            _context.City.UpdateRange(mappedCities);
            _context.SaveChanges();
        }

        public void Remove(City city)
        {
            var mappedCity = _mapper.Map<Entities.City>(city);
            _context.City.Remove(mappedCity);
            _context.SaveChanges();
        }

        public void Remove(City[] cities)
        {
            var mappedCities = _mapper.Map<Entities.City>(cities);
            _context.City.RemoveRange(mappedCities);
            _context.SaveChanges();
        }
    }
}
