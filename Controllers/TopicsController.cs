using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.TopicDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Topics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TopicDto>> CreateTopic(TopicCreateDto topicCreateDto, int userId)
        {
            var topic = _mapper.Map<Topic>(topicCreateDto);
            await _topicService.Create(topic);

            var topicDto = _mapper.Map<TopicDto>(topic);

            int topicId = topic.Id;

            await _topicService.AddUserToTopic(topicId, userId);

            return CreatedAtAction(nameof(GetTopic), new { id = topicDto.Id }, topicDto);

        }


        // POST: api/Topics/:topicId/join
        [HttpPost("{id}/join")]
        public async Task<ActionResult> JoinTopic(int id, int userId)
        {
            await _topicService.AddUserToTopic(id, userId);

            return CreatedAtAction("JoinTopic", id);

        }
        [HttpPatch("{id}/leave")]
        public async Task<ActionResult> LeaveTopic(int id, int userId)
        {
            await _topicService.RemoveUserFromTopic(id, userId);
            return NoContent();
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
