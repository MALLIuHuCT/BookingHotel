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
    public class HotelImageRepository : IHotelImageRepository
    {
        private readonly BookingHotelsContext _context;
        private readonly IMapper _mapper;

        public HotelImageRepository(BookingHotelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HotelImage[]> GetAll()
        {
            var hotelImages = await _context.HotelImage
                .AsNoTracking()
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<HotelImage[]>(source.Result));
            return hotelImages;
        }


        public async Task<HotelImage> GetById(int hotelImageId)
        {
            var hotel = await _context.HotelImage
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == hotelImageId)
                .ContinueWith(source => _mapper.Map<HotelImage>(source.Result)); ;
            return hotel;
        }

        public HotelImage Add(HotelImage hotelImage)
        {
            var mappedHotel = _mapper.Map<Entities.HotelImage>(hotelImage);
            _context.HotelImage.Add(mappedHotel);
            _context.SaveChanges();

            var unmappedEmployee = _mapper.Map<HotelImage>(mappedHotel);
            return unmappedEmployee;
        }

        public void Update(HotelImage hotelImage)
        {
            var mappedHotelImage = _mapper.Map<Entities.HotelImage>(hotelImage);
            _context.HotelImage.Update(mappedHotelImage);
            _context.SaveChanges();
        }

        public void Remove(int hotelImageId)
        {
            var removing = _context.HotelImage.First(x => x.Id == hotelImageId);
            _context.HotelImage.Remove(removing);
            _context.SaveChanges();
        }
    }
}
