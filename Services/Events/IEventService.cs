using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Events
{
    public interface IEventService : ICrudService<Event, int>
    {
        Task<IEnumerable<Event>> GetAllForTimeLine(int userId);
        Task<IEnumerable<Event>> GetUserEventsByUserId(int id);
        Task<IEnumerable<Event>> GetUserSuggestedEventsByUserId(int id);
        Task<Event> Update(Event entity);
    }
}
