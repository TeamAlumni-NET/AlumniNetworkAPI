using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Events
{
    public interface IEventService : ICrudService<Event, int>
    {
        Task<IEnumerable<Event>> GetUserEventsByUserId(int id);
        Task<IEnumerable<Event>> GetUserSuggestedEventsByUserId(int id);
    }
}
