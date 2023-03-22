using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.GroupDtos;
using AlumniNetworkAPI.Models.Models;
using AlumniNetworkAPI.Services.Groups;
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

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups(int userId)
        {
            var rawGroups = (_mapper.Map < IEnumerable < GroupDto >> (await _groupService.GetAll()));
            if(userId != null) {
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

        // GET: api/Groups/5
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

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupDto>> CreateGroup(GroupCreateDto groupCreateDto)
        {
            var group = _mapper.Map<Group>(groupCreateDto);
            await _groupService.Create(group);
          
            var groupDto = _mapper.Map<GroupDto>(group);

            int groupId = group.Id;
            int userId = group.CreatorId;

            await _groupService.AddUserToGroup(groupId, userId);

            return CreatedAtAction(nameof(GetGroup), new { id = groupDto.Id }, groupDto);

        }

        // DELETE: api/Groups/5
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
