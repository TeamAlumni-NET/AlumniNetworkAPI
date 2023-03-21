using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Events
{
    public interface IEventService : ICrudService<Event, int>
    {
        Task<IEnumerable<Event>> GetAllForTimeLine(int userId);
        Task<IEnumerable<Event>> GetByUserId(int id);
    }
}
