using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Domain.Exceptions;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.IServices;
using HotelBooking.Domain.Models;

namespace HotelBooking.Application
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<Booking[]> GetAll()
        {
            var bookings = await _bookingRepository.GetAll();
            return bookings;
        }

        public async Task<Booking[]> GetAllWithInclude()
        {
            var bookings = await _bookingRepository.GetAllWithInclude();
            return bookings;
        }

        public async Task<Booking> GetById(int bookingId)
        {
            if (bookingId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var booking = await _bookingRepository.GetById(bookingId);
            return booking;
        }

        public async Task<Booking> GetByIdWithInclude(int bookingId)
        {
            if (bookingId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var booking = await _bookingRepository.GetByIdWithInclude(bookingId);
            return booking;
        }
        public Task<Booking> Add(Booking booking)
        {
            if (booking == null)
            {
                throw new NullReferenceException("Booking is null");
            }
            try
            {
                return _bookingRepository.Add(booking);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException(ex.MessageError);
            }
        }
        public void Update(Booking booking)
        {
            if (booking == null)
            {
                throw new NullReferenceException("Booking is null");
            }

            //var validation = new HotelValidation().Validate(booking);
            //if (validation.IsValid == false)
            {
                //      throw new ServiceException(String.Join('\n', validation.Errors));
            }

            _bookingRepository.Update(booking);
        }

        public void RemoveById(int bookingId)
        {
            if (bookingId < 1)
            {
                throw new NullReferenceException("Booking id is incorrect");
            }

            _bookingRepository.Remove(bookingId);
        }
    }
}
