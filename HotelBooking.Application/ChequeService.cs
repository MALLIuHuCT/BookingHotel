using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.IServices;
using HotelBooking.Domain.Models;

namespace HotelBooking.Application
{
    public class ChequeService : IChequeService
    {
          private readonly IChequeRepository _chequeRepository;
        private readonly IMapper _mapper;

        public ChequeService(IChequeRepository chequeRepository, IMapper mapper)
        {
            _chequeRepository = chequeRepository;
            _mapper = mapper;
        }

        public async Task<Cheque[]> GetAll()
        {
            var cheques = await _chequeRepository.GetAll();
            return cheques;
        }

        public async Task<Cheque[]> GetAllWithInclude()
        {
            var cheques = await _chequeRepository.GetAllWithInclude();
            return cheques;
        }

        public async Task<Cheque> GetById(int chequeId)
        {
            if (chequeId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var cheque = await _chequeRepository.GetById(chequeId);
            return cheque;
        }

        public async Task<Cheque> GetByIdWithInclude(int chequeId)
        {
            if (chequeId < 1)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            var cheque = await _chequeRepository.GetByIdWithInclude(chequeId);
            return cheque;
        }
        public void Update(Cheque cheque)
        {
            if (cheque == null)
            {
                throw new NullReferenceException("Cheque is null");
            }

            //var validation = new HotelValidation().Validate(cheque);
            //if (validation.IsValid == false)
            {
                //      throw new ServiceException(String.Join('\n', validation.Errors));
            }

            _chequeRepository.Update(cheque);
        }

        public void RemoveById(int chequeId)
        {
            if (chequeId < 1)
            {
                throw new NullReferenceException("Cheque id is incorrect");
            }

            _chequeRepository.Remove(chequeId);
        }
    }
}
