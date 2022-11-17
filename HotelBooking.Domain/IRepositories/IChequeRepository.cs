using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IRepositories
{
    public interface IChequeRepository
    {
        Task<Cheque[]> GetAll();
        Task<Cheque[]> GetAllWithInclude();
        Task<Cheque> GetById(int chequeId);
        Task<Cheque> GetByIdWithInclude(int chequeId);
        Cheque Add(Cheque cheque);
        void Update(Cheque cheque);
        void Remove(int chequeId);
    }
}
