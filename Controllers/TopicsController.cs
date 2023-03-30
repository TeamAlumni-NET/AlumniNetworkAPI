using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.TopicDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Topics;
using AutoMapper;
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

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets spesific topic
        /// </summary>
        /// <param name="id">TopicId</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates new topic and adds creator as a member
        /// </summary>
        /// <param name="topicCreateDto"></param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TopicDto>> CreateTopic(TopicCreateDto topicCreateDto, int userId)
        {
            var topic = _mapper.Map<Topic>(topicCreateDto);
            await _topicService.Create(topic);

            var topicDto = _mapper.Map<TopicDto>(topic);

            int topicId = topic.Id;

            await _topicService.AddUserToTopic(topicId, userId);
            var answer = _mapper.Map<TopicUserDto>(topicDto);
            answer.IsMember = true;

            return CreatedAtAction(nameof(GetTopic), new { id = answer.Id }, answer);

        }


        /// <summary>
        /// Adds user to topic
        /// </summary>
        /// <param name="id">TopicId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        [HttpPost("{id}/join")]
        public async Task<ActionResult> JoinTopic(int id, int userId)
        {
            await _topicService.AddUserToTopic(id, userId);

            return CreatedAtAction("JoinTopic", id);

        }

        /// <summary>
        /// Removes user from a spesific topic
        /// </summary>
        /// <param name="id">TopicId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        [HttpPatch("{id}/leave")]
        public async Task<ActionResult> LeaveTopic(int id, int userId)
        {
            await _topicService.RemoveUserFromTopic(id, userId);
            return NoContent();
        }



        /// <summary>
        /// Deletes spesific topic
        /// </summary>
        /// <param name="id">TopicId</param>
        /// <returns></returns>
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
