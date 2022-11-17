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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<Hotel[]> GetAll()
        {
            var hotels = await _hotelRepository.GetAll();
            return hotels;
        }

        public async Task<Hotel[]> GetAllWithInclude()
        {
            var hotels = await _hotelRepository.GetAllWithInclude();
            return hotels;
        }

        public async Task<Hotel> GetById(int hotelId)
        {
            if (hotelId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var hotel = await _hotelRepository.GetById(hotelId);
            return hotel;
        }

        public async Task<Hotel> GetByIdWithInclude(int hotelId)
        {
            if (hotelId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var hotel = await _hotelRepository.GetByIdWithInclude(hotelId);
            return hotel;
        }
        public Hotel Add(Hotel hotel)
        {
            if (hotel == null)
            {
                throw new NullReferenceException("Hotel is null");
            }

            var validation = new HotelValidation().Validate(hotel);
            if (validation.IsValid == false)
            {
                throw new ServiceException(String.Join('\n', validation.Errors));
            }

            try
            {
                return _hotelRepository.Add(hotel);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException(ex.MessageError);
            }
        }
        public void Update(Hotel hotel)
        {
            if (hotel == null)
            {
                throw new NullReferenceException("Hotel is null");
            }

            var validation = new HotelValidation().Validate(hotel);
            if (validation.IsValid == false)
            {
                throw new ServiceException(String.Join('\n', validation.Errors));
            }

            try
            {
                _hotelRepository.Update(hotel);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException(ex.MessageError);
            }
        }

        public void RemoveById(int hotelId)
        {
            if (hotelId < 1)
            {
                throw new NullReferenceException("Hotel id is incorrect");
            }

            _hotelRepository.Remove(hotelId);
        }
    }
}