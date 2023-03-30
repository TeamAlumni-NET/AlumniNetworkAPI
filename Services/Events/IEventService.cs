using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Events
{
    public interface IEventService : ICrudService<Event, int>
    {
        /// <summary>
        /// Gets all public events
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        Task<IEnumerable<Event>> GetAllForTimeLine(int userId);

        /// <summary>
        /// Gets users all events
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        Task<IEnumerable<Event>> GetUserEventsByUserId(int id);

        /// <summary>
        /// Gets events suggested to user by users groups and topics
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        Task<IEnumerable<Event>> GetUserSuggestedEventsByUserId(int id);

        /// <summary>
        /// Gets all events of spesific topic
        /// </summary>
        /// <param name="id">TopicId</param>
        /// <returns></returns>
        Task<IEnumerable<Event>> GetEventsByTopic(int id);

        /// <summary>
        /// Gets all events of spesific group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Event>> GetEventsByGroup(int id);

        /// <summary>
        /// Adds user to spesific event
        /// </summary>
        /// <param name="id">EventId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>

        Task<Event> AddUserToEvent(int id, int userId);
    }
}
