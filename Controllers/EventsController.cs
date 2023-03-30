using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Events;
using AlumniNetworkAPI.Services.Groups;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IGroupService _groupService;

        private readonly AlumniNetworkDBContext _context;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IGroupService groupService, IMapper mapper, AlumniNetworkDBContext context)
        {
            _eventService = eventService;
            _mapper = mapper;
            _context = context;
            _groupService = groupService;
        }

        // GET: api/Events
        /// <summary>
        /// Gets all events based of target
        /// </summary>
        /// <param name="userId">A unique identifier for user</param>
        /// <param name="target">timeline or calendar</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets events suggested to user by groups and topics
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets events by spesific topic
        /// </summary>
        /// <param name="id">TopicId</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets events by spesific group
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets a spesific event
        /// </summary>
        /// <param name="id">EventId</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="eventCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(EventCreateDto eventCreateDto)
        {
            var eventT = _mapper.Map<Event>(eventCreateDto);
            eventT.LastUpdated = DateTime.Now;

            await _eventService.Create(eventT);

            var eventDto = _mapper.Map<EventNamesDto>(eventT);

            int eventId = eventT.Id;

            await _eventService.AddUserToEvent(eventId, eventT.EventCreatorId);

            //if (eventCreateDto.Groups.Count > 0)
            //{
            //    var groupId = eventCreateDto.Groups[0];
            //    await _groupService.AddEventToGroup(groupId, eventId);
            //}

            return CreatedAtAction(nameof(GetEvent), new { id = eventDto }, eventDto);
        }


        /// <summary>
        /// Deletes spesific event
        /// </summary>
        /// <param name="id">EventId</param>
        /// <returns></returns>
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

    }
}
