using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventUsersController : ControllerBase
    {
        private readonly AlumniNetworkDBContext _context;

        public EventUsersController(AlumniNetworkDBContext context)
        {
            _context = context;
        }

        // GET: api/EventUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUser>>> GetEventUsers()
        {
            return await _context.EventUsers.ToListAsync();
        }

        // GET: api/EventUsers/5
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

        // PUT: api/EventUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/EventUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: api/EventUsers/5
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
