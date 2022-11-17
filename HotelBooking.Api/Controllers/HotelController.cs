using Microsoft.AspNetCore.Http;
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
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get all hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Hotel> Get()
        {
            var hotel = _hotelService.GetAll();
            if (hotel == null)
                return NotFound();
            return new ObjectResult(hotel);
        }
        /// <summary>
        /// Get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            if (id < 1)
                ModelState.AddModelError("Error", "Неверный идентификатор");
            
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var hotel = _hotelService.GetById(id);
            if (hotel == null)
                return NotFound();
            return new ObjectResult(hotel);
        }

        /// <summary>
        /// Add hotel into database
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Hotel> Post(Hotel hotel)
        {
            var validation = new HotelValidation().Validate(hotel);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            Hotel addedProduct;
            try
            {
                addedProduct = _hotelService.Add(hotel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return new ObjectResult(addedProduct);
        }

        /// <summary>
        /// Update hotel data
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(Hotel hotel)
        {
            var validation = new HotelValidation().Validate(hotel);
            if (validation.IsValid == false)
            {
                return BadRequest();
            }
            try
            {
                _hotelService.Update(hotel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        /// <summary>
        /// Delete hotel by id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(int hotelId)
        {
            try
            {
                _hotelService.RemoveById(hotelId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
