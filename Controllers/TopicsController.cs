using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.TopicDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Topics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly AlumniNetworkDBContext _context;
        private readonly IMapper _mapper;

        public TopicsController(AlumniNetworkDBContext context, IMapper mapper, ITopicService topicService)
        {
            _context = context;
            _mapper = mapper;
            _topicService = topicService;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopics(int userId)
        {
            var rawTopics = (_mapper.Map<IEnumerable<TopicDto>>(await _topicService.GetAll()));

            List<TopicUserDto> filteredTopicsForUser = new List<TopicUserDto> { };

            foreach (var group in rawTopics)
            {
                filteredTopicsForUser.Add(new TopicUserDto()
                {
                    Id = group.Id,
                    Name = group.Name,
                    Description = group.Description,
                    IsMember = group.Users.Contains(userId)
                });
            }
            return base.Ok(filteredTopicsForUser);
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.Id)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopic", new { id = topic.Id }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }
    }
}
