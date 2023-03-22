﻿using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Posts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            _postService= postService;
            _mapper= mapper;
           
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts(int userId, string timeline)
        {
            if (timeline == null)
            {
                return Ok(_mapper.Map<IEnumerable<PostDto>>(await _postService.GetAll()));
            }
            else
            {
                var result = _mapper.Map<IEnumerable<TimelinePostDto>>(await _postService.GetTimeline(userId));
                foreach (var post in result)
                {
                    post.Posts = _mapper.Map < List<SimplePostDto>>(result.Where(p => post.Id == p.ParentPostId).ToList());
                }
                result = result.Where(post => post.Title != null).ToList();
                return Ok(result);
            }
            
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            try
            {
                return Ok(_mapper.Map<PostDto>(await _postService.GetById(id)));
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
        public async Task<ActionResult<ChildPostRootDto>> GetPostThread(int id)
        {
            try
            {
                return Ok(_mapper.Map<ChildPostRootDto>(await _postService.GetAllChildPosts(id)));
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
            var post = _mapper.Map<Post>(createPostDto);
            post.TimeStamp = DateTime.Now;
            await _postService.Create(post);

            var postDto = _mapper.Map<PostDto>(post);

            return CreatedAtAction(nameof(GetPost), new { id = postDto.Id }, postDto); 
        }




        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, EditPostDto editPostDto)
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

            return NoContent();
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
