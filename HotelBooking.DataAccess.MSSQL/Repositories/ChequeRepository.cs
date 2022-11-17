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
    public class ChequeRepository : IChequeRepository
    {
        private readonly BookingHotelsContext _context;
        private readonly IMapper _mapper;

        public ChequeRepository(BookingHotelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cheque[]> GetAll()
        {
            var cheques = await _context.Cheque
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Cheque[]>(source.Result));
            return cheques;
        }

        public async Task<Cheque[]> GetAllWithInclude()
        {
            var cheques = await _context.Cheque
                .Include(x => x.PaymentType)
                .Include(x => x.Booking)
                .ToArrayAsync()
                .ContinueWith(source => _mapper.Map<Cheque[]>(source.Result));
            return cheques;
        }

        public async Task<Cheque> GetById(int roomId)
        {
            var cheque = await _context.Cheque.FirstOrDefaultAsync(x => x.Id == roomId)
                .ContinueWith(source => _mapper.Map<Cheque>(source.Result)); ;
            return cheque;
        }

        public async Task<Cheque> GetByIdWithInclude(int roomId)
        {
            var cheque = await _context.Cheque.Where(x => x.Id == roomId)
                .Include(x => x.PaymentType)
                .Include(x => x.Booking)
                .FirstOrDefaultAsync()
                .ContinueWith(source => _mapper.Map<Cheque>(source.Result));
            return cheque;
        }

        public Cheque Add(Cheque cheque)
        {
            var mappedCheque = _mapper.Map<Entities.Cheque>(cheque);
            _context.Cheque.Add(mappedCheque);
            _context.SaveChanges();

            var unmappedCheque = _mapper.Map<Cheque>(mappedCheque);
            return unmappedCheque;
        }

        public void Update(Cheque cheque)
        {
            var mappedCheque = _mapper.Map<Entities.Cheque>(cheque);
            _context.Cheque.Update(mappedCheque);
            _context.SaveChanges();
        }

        public void Remove(int roomId)
        {
            var removing = _context.Cheque.First(x => x.Id == roomId);
            _context.Cheque.Remove(removing);
            _context.SaveChanges();
        }
    }
}