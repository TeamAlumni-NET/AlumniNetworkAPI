using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.UserDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Users;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AlumniNetworkDBContext _context;
        private readonly IMapper _mapper;

        public UsersController(AlumniNetworkDBContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserDto>>(await _userService.GetAll()));
        }

        /// <summary>
        /// Get single user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User by id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try
            {
                return Ok(_mapper.Map<UserDto>(await _userService.GetById(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("user/{username}")]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            try
            {
                return Ok(_mapper.Map<UserDto>(await _userService.GetByUsername(username)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{username}")]
        public async Task<IActionResult> PatchUser(string username, UserEditDto userEditDto)
        {
            if (username != userEditDto.Username)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userEditDto);

            try
            {
                await _userService.PatchByUsername(user);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
            // POST: api/Users
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
        public async Task<ActionResult<UserCreateDto>> PostUser(UserCreateDto user)
        {
            try
            {
                var newUser = _mapper.Map<User>(user);
                return CreatedAtAction("PostUser", _mapper.Map<UserCreateDto>(await _userService.Create(newUser)));
            }
            catch (UserAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }

        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
