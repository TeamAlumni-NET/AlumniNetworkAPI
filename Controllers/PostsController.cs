using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.DTOs.UserDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Posts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;

        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts(int userId, string target)
        {
            if (target == "timeline")
            {
                return Ok(_mapper.Map<IEnumerable<TimelinePostDto>>(await _postService.GetTimeline(userId)));
            }
            else if (target == "group")
            {
                return Ok(_mapper.Map<IEnumerable<TimelinePostDto>>(await _postService.GetGroup(userId)));
            }
            else if (target == "topic")
            {
                return Ok(_mapper.Map<IEnumerable<TimelinePostDto>>(await _postService.GetTopicsPosts(userId)));
            }
            else if (target == "dashboard") return Ok(_mapper.Map<IEnumerable<TimelinePostDto>>(await _postService.GetDashboard(userId)));
            else
            {
                return Ok(_mapper.Map<IEnumerable<PostDto>>(await _postService.GetAll()));
            }

        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostByIdDto>> GetPost(int id)
        {
            try
            {
                return Ok(_mapper.Map<PostByIdDto>(await _postService.GetById(id)));
            }
            catch (PostNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        [HttpGet("thread/{id}")]
        public async Task<ActionResult<Task<IEnumerable<ChildPostDto>>>> GetPostThread(int id)
        {
            try
            {
                return Ok(_mapper.Map < IEnumerable<ChildPostDto>>(await _postService.GetAllChildPosts(id)));
                
            }
            catch (PostNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        [HttpGet("thread/event/{id}")]
        public async Task<ActionResult<Task<IEnumerable<ChildPostDto>>>> GetEventThread(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ChildPostDto>>(await _postService.GetAllChildPostsEvent(id)));

            }
            catch (PostNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }



        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostDto>> PostPost(CreatePostDto createPostDto)
        {
            var userData = createPostDto.User;
            var newPost = _mapper.Map<NewPostDto>(createPostDto);
            var post = _mapper.Map<Post>(newPost);
            post.TimeStamp = DateTime.Now;
            await _postService.Create(post);

            if (post.ParentPostId != null || post.EventId != null)
            {
                var answer = _mapper.Map<ChildPostDto>(post);
                answer.user = _mapper.Map<UserSimpleDto>(userData);
                return CreatedAtAction(nameof(GetPost), new { id = answer.Id }, answer);
            }
            var postDto = _mapper.Map<TimelinePostDto>(post);
            postDto.User = userData;
            return CreatedAtAction(nameof(GetPost), new { id = postDto.Id }, postDto);
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<PostDto>> PutPost(int id, EditPostDto editPostDto)
        {
            if (id != editPostDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _postService.Update(_mapper.Map<Post>(editPostDto));
            }
            catch (PostNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return CreatedAtAction(nameof(GetPost), new { id = editPostDto.Id }, editPostDto);
        }



        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.DeleteById(id);
            }
            catch (PostNotFoundException ex)
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
