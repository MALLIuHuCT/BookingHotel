using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.IServices
{
    public interface IChequeService
    {
        Task<Cheque[]> GetAll();
        Task<Cheque[]> GetAllWithInclude();
        Task<Cheque> GetById(int chequeId);
        Task<Cheque> GetByIdWithInclude(int chequeId);
        void Update(Cheque cheque);
        void RemoveById(int chequeId);
    }
}
