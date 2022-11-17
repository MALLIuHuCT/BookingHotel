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
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        /// <summary>
        /// Get all city data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _cityService.GetAll().Result;
        }

        /// <summary>
        /// Get city data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            if (id < 1)
                ModelState.AddModelError("Error", "Неверный идентификатор");
            
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var city = _cityService.Get(id);
            if (city == null)
                return NotFound();
            return new ObjectResult(city);
        }

        /// <summary>
        /// Update city data 
        /// </summary>
        /// <param name="city"></param>
        [HttpPut]
        public ActionResult Put([FromBody] City city)
        {
            /*
            var validation = new BookingValidation().Validate(city);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            */
            try
            {
                _cityService.Update(city);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
