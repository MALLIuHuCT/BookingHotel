using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Domain.Exceptions;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.IServices;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Validation;

namespace HotelBooking.Application
{
    public class CityService : ICityService
    {
         private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<City[]> GetAll()
        {
            var cities = await _cityRepository.GetAll();
            return cities;
        }

        public async Task<City> Get(int hotelId)
        {
            if (hotelId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var city = await _cityRepository.Get(hotelId);
            return city;
        }

        public void Remove(City city)
        {
            if (city == null)
            {
                throw new NullReferenceException("City is null");
            }

            var validation = new CityValidation().Validate(city);
            if (validation.IsValid == false)
            {
                throw new ServiceException(String.Join('\n', validation.Errors));
            }

            _cityRepository.Remove(city);
        }

        public void Remove(City[] cities)
        {
            if (cities == null)
            {
                throw new NullReferenceException("Hotels are null");
            }

            for (int i = 0; i < cities.Length; i++)
            {
                var validation = new CityValidation().Validate(cities[i]);
                if (validation.IsValid == false)
                {
                    throw new ServiceException(String.Join('\n', validation.Errors));
                }
            }

            _cityRepository.Remove(cities);
        }

        public void Update(City city)
        {
            if (city == null)
            {
                throw new NullReferenceException("City is null");
            }

            var validation = new CityValidation().Validate(city);
            if (validation.IsValid == false)
            {
                throw new ServiceException(String.Join('\n', validation.Errors));
            }

            _cityRepository.Update(city);
        }

        public void Update(City[] cities)
        {
            if (cities == null)
            {
                throw new NullReferenceException("City is null");
            }

            for (int i = 0; i < cities.Length; i++)
            {
                var validation = new CityValidation().Validate(cities[i]);
                if (validation.IsValid == false)
                {
                    throw new ServiceException(String.Join('\n', validation.Errors));
                }
            }

            _cityRepository.Update(cities);
        }
    }
}
