using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.GroupDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Groups;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mime;

namespace AlumniNetworkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly AlumniNetworkDBContext _context;
        private readonly IMapper _mapper;

        public GroupsController(AlumniNetworkDBContext context, IMapper mapper, IGroupService groupService)
        {
            _context = context;
            _mapper = mapper;
            _groupService = groupService;
        }

        /// <summary>
        /// Gets all public groups and private groups user is a member
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups(int userId)
        {
            var rawGroups = (_mapper.Map<IEnumerable<GroupDto>>(await _groupService.GetAll()));
            if (userId != null)
            {
                var filteredGroups = rawGroups.Where(g => !Convert.ToBoolean(g.IsPrivate) || Convert.ToBoolean(g.IsPrivate) && g.Users.Contains(userId));

                List<GroupUserDto> filteredGroupsForUser = new List<GroupUserDto> { };

                foreach (var group in filteredGroups)
                {
                    filteredGroupsForUser.Add(new GroupUserDto()
                    {
                        Id = group.Id,
                        Name = group.Name,
                        Description = group.Description,
                        IsPrivate = group.IsPrivate,
                        IsMember = group.Users.Contains(userId)
                    });
                }

                return base.Ok(filteredGroupsForUser);
            }
            else
            {
                return base.Ok(rawGroups);
            }
        }

        /// <summary>
        /// Gets a spesific group by id
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }


        /// <summary>
        /// Creates a new group and adds creator to group
        /// </summary>
        /// <param name="groupCreateDto"></param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GroupDto>> CreateGroup(GroupCreateDto groupCreateDto, int userId)
        {
            var group = _mapper.Map<Group>(groupCreateDto);
            await _groupService.Create(group);

            var groupDto = _mapper.Map<GroupDto>(group);


            int groupId = group.Id;

            await _groupService.AddUserToGroup(groupId, userId);
            var answer = _mapper.Map<GroupUserDto>(groupDto);
            answer.IsMember = true;

            return CreatedAtAction(nameof(GetGroup), new { id = answer.Id }, answer);

        }


        /// <summary>
        /// Adds user to spesific group
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        [HttpPost("{id}/join")]
        public async Task<ActionResult> JoinGroup(int id, int userId)
        {
            try
            {
                await _groupService.AddUserToGroup(id, userId);

                return CreatedAtAction("JoinGroup", id);
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Removes user from spesific group
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        [HttpPatch("{id}/leave")]
        public async Task<ActionResult> LeaveGroup(int id, int userId)
        {
            await _groupService.RemoveUserToGroup(id, userId);
            return NoContent();
        }




        /// <summary>
        /// Deletes spesific group
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
