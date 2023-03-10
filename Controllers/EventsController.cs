using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Events;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using AlumniNetworkAPI.Exceptions;
using System.Net;

namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return Ok(await _eventService.GetAll());
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            try
            {
                return await _eventService.GetById(id);
            }
            catch (EventNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
         * Input for postEvent needs following details:
         *  "lastUpdated": "0001-01-01T00:00:00",
         *  "name": "String",
         *  "description": "String",
         *  "allowGuests": true,
         *  "startTime": "2023-07-06T17:30:00",
         *  "endTime": "2023-07-06T21:00:00",
         *  "eventCreatorId": 1,
         */
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event entity)
        {
            return CreatedAtAction("GetEvent", new { id = entity.Id }, await _eventService.Create(entity));
        }


        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                await _eventService.DeleteById(id);
            }
            catch(EventNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }


        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        /*
         * Swagger test request body:
         *  {
        "id": 4,
        "lastUpdated": "2023-03-13T08:28:18.128",
        "name": "TestiUpdate",
        "description": "For testing update",
        "allowGuests": true,
        "startTime": "2023-04-13T08:28:18.128",
        "endTime": "2023-04-13T08:28:18.128",
        "eventCreatorId": 2
        }
        */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            try
            {
                await _eventService.Update(entity);
            }
            catch (EventNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });

            }

            return NoContent();
        }
       }
}
