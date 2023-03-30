﻿using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Groups
{
    public interface IGroupService : ICrudService<Group, int>
    {
        Task<Group> AddUserToGroup(int id, int userId);
        Task<Group> RemoveUserToGroup(int groupId, int userId);
        Task<Group> AddEventToGroup(int groupId, int eventId);
    }
}
