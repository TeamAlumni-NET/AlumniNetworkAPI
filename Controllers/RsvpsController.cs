using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RsvpsController : ControllerBase
    {
        private readonly AlumniNetworkDBContext _context;

        public RsvpsController(AlumniNetworkDBContext context)
        {
            _context = context;
        }

        // GET: api/Rsvps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rsvp>>> GetRsvps()
        {
            return await _context.Rsvps.ToListAsync();
        }

        // GET: api/Rsvps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rsvp>> GetRsvp(int id)
        {
            var rsvp = await _context.Rsvps.FindAsync(id);

            if (rsvp == null)
            {
                return NotFound();
            }

            return rsvp;
        }

        // PUT: api/Rsvps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRsvp(int id, Rsvp rsvp)
        {
            if (id != rsvp.Id)
            {
                return BadRequest();
            }

            _context.Entry(rsvp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RsvpExists(id))
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

        // POST: api/Rsvps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rsvp>> PostRsvp(Rsvp rsvp)
        {
            _context.Rsvps.Add(rsvp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRsvp", new { id = rsvp.Id }, rsvp);
        }

        // DELETE: api/Rsvps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRsvp(int id)
        {
            var rsvp = await _context.Rsvps.FindAsync(id);
            if (rsvp == null)
            {
                return NotFound();
            }

            _context.Rsvps.Remove(rsvp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RsvpExists(int id)
        {
            return _context.Rsvps.Any(e => e.Id == id);
        }
    }
}
