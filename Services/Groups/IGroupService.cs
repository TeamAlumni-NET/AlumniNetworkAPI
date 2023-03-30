using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Groups
{
    public interface IGroupService : ICrudService<Group, int>
    {
        /// <summary>
        /// Adds user to spesific group as a member
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        Task<Group> AddUserToGroup(int id, int userId);

        /// <summary>
        /// Removes spesific user from a group
        /// </summary>
        /// <param name="groupId">GroupId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        Task<Group> RemoveUserToGroup(int groupId, int userId);

        /// <summary>
        /// Adds an event to a spesific group
        /// </summary>
        /// <param name="groupId">GroupId</param>
        /// <param name="eventId">EventId</param>
        /// <returns></returns>
        Task<Group> AddEventToGroup(int groupId, int eventId);
    }
}
