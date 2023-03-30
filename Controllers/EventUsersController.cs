using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class EventUsersController : ControllerBase
    {
        private readonly AlumniNetworkDBContext _context;

        public EventUsersController(AlumniNetworkDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all users by event
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUser>>> GetEventUsers()
        {
            return await _context.EventUsers.ToListAsync();
        }

        /// <summary>
        /// Gets a spesific user of event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EventUser>> GetEventUser(int id)
        {
            var eventUser = await _context.EventUsers.FindAsync(id);

            if (eventUser == null)
            {
                return NotFound();
            }

            return eventUser;
        }

        /// <summary>
        /// Edit event user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventUser(int id, EventUser eventUser)
        {
            if (id != eventUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(eventUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Adds user to event
        /// </summary>
        /// <param name="eventUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EventUser>> PostEventUser(EventUser eventUser)
        {
            _context.EventUsers.Add(eventUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventUserExists(eventUser.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEventUser", new { id = eventUser.UserId }, eventUser);
        }

        /// <summary>
        /// Deletes user from event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventUser(int id)
        {
            var eventUser = await _context.EventUsers.FindAsync(id);
            if (eventUser == null)
            {
                return NotFound();
            }

            _context.EventUsers.Remove(eventUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventUserExists(int id)
        {
            return _context.EventUsers.Any(e => e.UserId == id);
        }
    }
}
