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
    public class HotelImageService : IHotelImageService
    {
        private readonly IHotelImageRepository _hotelImageRepository;
        private readonly IMapper _mapper;

        public HotelImageService(IHotelImageRepository hotelImageRepository, IMapper mapper)
        {
            _hotelImageRepository = hotelImageRepository;
            _mapper = mapper;
        }

        public async Task<HotelImage[]> GetAll()
        {
            var hotels = await _hotelImageRepository.GetAll();
            return hotels;
        }

        public async Task<HotelImage> GetById(int hotelImageId)
        {
            if (hotelImageId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var hotelImage = await _hotelImageRepository.GetById(hotelImageId);
            return hotelImage;
        }

        public HotelImage Add(HotelImage hotelImage)
        {
            if (hotelImage == null)
            {
                throw new NullReferenceException("HotelImage is null");
            }

            //var validation = new HotelValidation().Validate(hotelImage);
            //if (validation.IsValid == false)
            {
                //  throw new ServiceException(String.Join('\n', validation.Errors));
            } 
            
            return _hotelImageRepository.Add(hotelImage);
        }

        public void Update(HotelImage hotelImage)
        {
            if (hotelImage == null)
            {
                throw new NullReferenceException("HotelImage is null");
            }

            //var validation = new HotelValidation().Validate(hotelImage);
            //if (validation.IsValid == false)
            {
              //  throw new ServiceException(String.Join('\n', validation.Errors));
            }

            _hotelImageRepository.Update(hotelImage);
        }

        public void RemoveById(int hotelImageId)
        {
            if (hotelImageId < 1)
            {
                throw new NullReferenceException("HotelImage id is incorrect");
            }

            _hotelImageRepository.Remove(hotelImageId);
        }
    }
}
