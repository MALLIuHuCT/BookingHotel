using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Domain.IServices;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Validation;


namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Get all booking data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return _bookingService.GetAll().Result;
        }

        /// <summary>
        /// Get booking data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id)
        {
            if (id < 1)
                ModelState.AddModelError("Error", "Неверный идентификатор");
            
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var hotel = _bookingService.GetById(id);
            if (hotel == null)
                return NotFound();
            return new ObjectResult(hotel);
        }

        /// <summary>
        /// Add booking into database
        /// </summary>
        /// <param name="booking"></param>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Booking booking)
        {
            var validation = new BookingValidation().Validate(booking);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            Booking addedBooking;
            try
            {
                addedBooking = _bookingService.Add(booking).Result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return new ObjectResult(addedBooking);
        }

        /// <summary>
        /// Update booking data 
        /// </summary>
        /// <param name="booking"></param>
        [HttpPut]
        public ActionResult Put([FromBody] Booking booking)
        {
            var validation = new BookingValidation().Validate(booking);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            try
            {
                _bookingService.Update(booking);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Delete booking by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _bookingService.RemoveById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
