using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AlumniNetworkAPI.Services.Events
{
    public class EventService : IEventService
    {
        private readonly AlumniNetworkDBContext _dbContext;

        public EventService(AlumniNetworkDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _dbContext.Events.ToListAsync();
        }


        public async Task<Event> GetById(int id)
        {
            var eventById = await _dbContext.Events.FindAsync(id);
            await _dbContext.Events.FindAsync(id);

            if (eventById == null) 
            {
            throw new EventNotFoundException(id);
        }

            return eventById;
        }

        public async Task<Event> Create(Event entity)
        {
            _dbContext.Events.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteById(int id)
        {
            var deletedEvent = await _dbContext.Events.FindAsync(id);
            if (deletedEvent == null)
            {
                throw new EventNotFoundException(id);
            }

            _dbContext.Events.Remove(deletedEvent);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<Event> Update(Event entity)
        {
            var searchEvent = await _dbContext.Events.AnyAsync(x => x.Id == entity.Id);
            if (searchEvent == null)
            {
                throw new EventNotFoundException(entity.Id);
            }

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
         
        }

       
    }
}
