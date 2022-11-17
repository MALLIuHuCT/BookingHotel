using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Domain.IServices;
using HotelBooking.Domain.Models;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeController : ControllerBase
    {
        private readonly IChequeService _chequeService;

        public ChequeController(IChequeService chequeService)
        {
            _chequeService = chequeService;
        }

        /// <summary>
        /// Get all cheque data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Cheque> Get()
        {
            return _chequeService.GetAll().Result;
        }

        /// <summary>
        /// Get cheque data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Cheque> Get(int id)
        {
            if (id < 1)
                ModelState.AddModelError("Error", "Неверный идентификатор");
            
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var cheque = _chequeService.GetById(id);
            if (cheque == null)
                return NotFound();
            return new ObjectResult(cheque);
        }

        /// <summary>
        /// Update cheque data 
        /// </summary>
        /// <param name="cheque"></param>
        [HttpPut]
        public ActionResult Put([FromBody] Cheque cheque)
        {
            /*
            var validation = new BookingValidation().Validate(cheque);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            */
            try
            {
                _chequeService.Update(cheque);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Delete cheque by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _chequeService.RemoveById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
