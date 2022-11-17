using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DataAccess.MSSQL.Repositories
{

    public class HotelRepository : IHotelRepository
    {
        private readonly BookingHotelsContext _context;
        private readonly IMapper _mapper;

        public HotelRepository(BookingHotelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Hotel[]> GetAll()
        {
            var hotels = await _context.Hotel
                .AsNoTracking()
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Hotel[]>(source.Result));
            return hotels;
        }

        public async Task<Hotel[]> GetAllWithInclude()
        {
            var hotels = await _context.Hotel
                .AsNoTracking()
                .Include(x => x.HotelClass)
                .Include(x => x.Image)
                .Include(x => x.Street).ThenInclude(x => x.City)
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Hotel[]>(source.Result));
            return hotels;
        }

        public async Task<Hotel> GetById(int hotelId)
        {
            var hotel = await _context.Hotel
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == hotelId)
                .ContinueWith(source => _mapper.Map<Hotel>(source.Result)); ;
            return hotel;
        }

        public async Task<Hotel> GetByIdWithInclude(int hotelId)
        {
            var hotel = await _context.Hotel.Where(x => x.Id == hotelId)
                .AsNoTracking()
                .Include(x => x.HotelClass)
                .Include(x => x.Image)
                .Include(x => x.Street).ThenInclude(x => x.City)
                .FirstOrDefaultAsync()
                .ContinueWith(source => _mapper.Map<Hotel>(source.Result));
            return hotel;
        }

        public Hotel Add(Hotel hotel)
        {
            var mappedHotel = _mapper.Map<Entities.Hotel>(hotel);
            _context.Hotel.Add(mappedHotel);
            _context.SaveChanges();

            var unmappedEmployee = _mapper.Map<Hotel>(mappedHotel);
            return unmappedEmployee;
        }

        public void Update(Hotel hotel)
        {
            var mappedHotel = _mapper.Map<Entities.Hotel>(hotel);
            _context.Hotel.Update(mappedHotel);
            _context.SaveChanges();
        }

        public void Remove(int hotelId)
        {
            var removing = _context.Hotel.First(x => x.Id == hotelId);
            _context.Hotel.Remove(removing);
            _context.SaveChanges();
        }
    }
}
