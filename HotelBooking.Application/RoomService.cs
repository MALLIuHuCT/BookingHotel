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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository hotelRepository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _roomRepository = hotelRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<Room[]> GetAll()
        {
            var rooms = await _roomRepository.GetAll();
            return rooms;
        }

        public async Task<Room[]> GetAllWithInclude()
        {
            var rooms = await _roomRepository.GetAllWithInclude();
            return rooms;
        }

        public async Task<Room[]> GetAllByHotelId(int hotelId)
        {
            var rooms = await _roomRepository.GetAllByHotelId(hotelId);
            var freeRoms = new List<Room>();
            foreach (var room in rooms)
            {
                var bookingsByCurRoom = await _bookingRepository.GetAllWithIncludeByRoomId(room.Id);
                bool isFreeRoom = true;
                foreach (var bookingCurRoom in bookingsByCurRoom)
                {
                    if (bookingCurRoom.BookingStatus.Id == 2)
                        isFreeRoom = false;
                }
                if (isFreeRoom)
                    freeRoms.Add(room);
            }
            return freeRoms.ToArray();
        }

        public async Task<Room[]> GetAllWithIncludeByHotelId(int hotelId)
        {
            var rooms = await _roomRepository.GetAllWithIncludeByHotelId(hotelId);
            var freeRoms = new List<Room>();
            foreach (var room in rooms)
            {
                var bookingsByCurRoom = await _bookingRepository.GetAllWithIncludeByRoomId(room.Id);
                bool isFreeRoom = true;
                foreach (var bookingCurRoom in bookingsByCurRoom)
                {
                    if (bookingCurRoom.BookingStatus.Id == 2)
                        isFreeRoom = false;
                }
                if (isFreeRoom)
                    freeRoms.Add(room);
            }
            return freeRoms.ToArray();
        }

        public async Task<Room> GetById(int hotelId)
        {
            if (hotelId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var room = await _roomRepository.GetById(hotelId);
            return room;
        }

        public async Task<Room> GetByIdWithInclude(int hotelId)
        {
            if (hotelId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var room = await _roomRepository.GetByIdWithInclude(hotelId);
            return room;
        }
        public Room Add(Room room)
        {
            if (room == null)
            {
                throw new NullReferenceException("Room is null");
            }

            /*
            var validation = new HotelValidation().Validate(room);
            if (validation.IsValid == false)
            {
                throw new ServiceException(String.Join('\n', validation.Errors));
            }
            */

            try
            {
                return _roomRepository.Add(room);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException(ex.MessageError);
            }
        }
        public void Update(Room room)
        {
            if (room == null)
            {
                throw new NullReferenceException("Room is null");
            }

            //var validation = new HotelValidation().Validate(room);
            //if (validation.IsValid == false)
            {
            //      throw new ServiceException(String.Join('\n', validation.Errors));
            }

            _roomRepository.Update(room);
        }

        public void RemoveById(int hotelId)
        {
            if (hotelId < 1)
            {
                throw new NullReferenceException("Room id is incorrect");
            }

            _roomRepository.Remove(hotelId);
        }
    }
}
