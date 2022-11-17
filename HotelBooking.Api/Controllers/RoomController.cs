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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// Get all room data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return _roomService.GetAll().Result;
        }

        /// <summary>
        /// Get room data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            if (id < 1)
                ModelState.AddModelError("Error", "Неверный идентификатор");
            
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var room = _roomService.GetById(id);
            if (room == null)
                return NotFound();
            return new ObjectResult(room);
        }

        /// <summary>
        /// Add room into database
        /// </summary>
        /// <param name="room"></param>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Room room)
        {
            /*
            var validation = new Room().Validate(room);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            */
            Room addedRoom;
            try
            {
                addedRoom = _roomService.Add(room);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return new ObjectResult(addedRoom);
        }

        /// <summary>
        /// Update room data 
        /// </summary>
        /// <param name="room"></param>
        [HttpPut]
        public ActionResult Put([FromBody] Room room)
        {
            /*
            var validation = new BookingValidation().Validate(room);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            */
            try
            {
                _roomService.Update(room);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Delete room by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _roomService.RemoveById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
