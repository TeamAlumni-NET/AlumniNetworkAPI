using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Events;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly AlumniNetworkDBContext _context;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper, AlumniNetworkDBContext context)
        {
            _eventService = eventService;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents(int userId, string target)
        {
            try
            {

                if (target == "timeline")
                {
                    return Ok(_mapper.Map<IEnumerable<EventNamesDto>>(await _eventService.GetAllForTimeLine(userId)));
                }
                else if (target == "calendar")
                {
                    return Ok(_mapper.Map<IEnumerable<EventCalendarDto>>(await _eventService.GetUserEventsByUserId(userId)));
                }
                return Ok(_mapper.Map<IEnumerable<EventDto>>(await _eventService.GetAll()));
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
        [HttpGet("topic/{id}")]
        public async Task<ActionResult<IEnumerable<EventCalendarDto>>> GetTopicEvents(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<EventCalendarDto>>(await _eventService.GetEventsByTopic(id)));
            }
            catch (EventNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        [HttpGet("group/{id}")]
        public async Task<ActionResult<IEnumerable<EventCalendarDto>>> GetGroupEvents(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<EventCalendarDto>>(await _eventService.GetEventsByGroup(id)));
            }
            catch (EventNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eventT = await _context.Events.FindAsync(id);

            if (eventT == null)
            {
                return NotFound();
            }

            return eventT;
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
        public async Task<ActionResult<EventDto>> CreateEvent(EventCreateDto eventCreateDto)
        {
            var eventT = _mapper.Map<Event>(eventCreateDto);
            eventT.LastUpdated = DateTime.Now;

            await _eventService.Create(eventT);

            var eventDto = _mapper.Map<EventDto>(eventT);

          

            return CreatedAtAction(nameof(GetEvent), new { id = eventDto }, eventDto);
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
