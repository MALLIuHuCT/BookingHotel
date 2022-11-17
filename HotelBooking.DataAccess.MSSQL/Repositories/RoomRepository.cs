using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DataAccess.MSSQL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingHotelsContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(BookingHotelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Room[]> GetAll()
        {
            var rooms = await _context.Room
                .AsNoTracking()
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Room[]>(source.Result));
            return rooms;
        }

        public async Task<Room[]> GetAllWithInclude()
        {
            var rooms = await _context.Room
                .Include(x => x.RoomType)
                .Include(x => x.RoomInfo).ThenInclude(x => x.Image)
                .AsNoTracking()
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Room[]>(source.Result));
            return rooms;
        }

        public async Task<Room[]> GetAllByHotelId(int hotelId)
        {
            var rooms = await _context.Room
                .Where(x => x.HotelId == hotelId)
                .AsNoTracking()
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Room[]>(source.Result));
            return rooms;
        }

        public async Task<Room[]> GetAllWithIncludeByHotelId(int hotelId)
        {
            var rooms = await _context.Room
                .Where(x => x.HotelId == hotelId)
                .Include(x => x.RoomType)
                .Include(x => x.RoomInfo).ThenInclude(x => x.Image)
                .AsNoTracking()
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Room[]>(source.Result));
            return rooms;
        }

        public async Task<Room> GetById(int roomId)
        {
            var room = await _context.Room
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == roomId)
                .ContinueWith(source => _mapper.Map<Room>(source.Result)); ;
            return room;
        }

        public async Task<Room> GetByIdWithInclude(int roomId)
        {
            var room = await _context.Room.Where(x => x.Id == roomId)
                .Include(x => x.RoomType)
                .Include(x => x.RoomInfo).ThenInclude(x => x.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ContinueWith(source => _mapper.Map<Room>(source.Result));
            return room;
        }

        public Room Add(Room room)
        {
            var mappedRoom = _mapper.Map<Entities.Room>(room);
            _context.Room.Add(mappedRoom);
            _context.SaveChanges();

            var unmappedRoom = _mapper.Map<Room>(mappedRoom);
            return unmappedRoom;
        }

        public void Update(Room room)
        {
            var mappedRoom = _mapper.Map<Entities.Room>(room);
            _context.Room.Update(mappedRoom);
            _context.SaveChanges();
        }

        public void Remove(int roomId)
        {
            var removing = _context.Room.First(x => x.Id == roomId);
            _context.Room.Remove(removing);
            _context.SaveChanges();
        }
    }
}
