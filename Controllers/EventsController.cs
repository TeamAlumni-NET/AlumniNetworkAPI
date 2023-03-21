using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Events;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            return Ok(_mapper.Map<IEnumerable<EventDto>>(await _eventService.GetAll()));
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

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<EventCalendarDto>>> GetEvents(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<EventCalendarDto>>(await _eventService.GetUserEventsByUserId(id)));
            }
            catch (EventNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        [HttpGet("suggested/{id}")]
        public async Task<ActionResult<IEnumerable<EventCalendarDto>>> GetSuggestedEvents(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<EventCalendarDto>>(await _eventService.GetUserSuggestedEventsByUserId(id)));
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
            catch (EventNotFoundException ex)
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
