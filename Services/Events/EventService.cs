﻿using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

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

            if (eventById == null)
            {
                throw new EventNotFoundException(id);
            }

            return eventById;
        }
        public async Task<IEnumerable<Event>> GetUserEventsByUserId(int id)
        {
            var eventById = await _dbContext.EventUsers
                .Include(x => x.Event)
                .Where(x => x.UserId == id)
                .Select(x => x.Event)
                .ToListAsync();

            if (eventById == null)
            {
                throw new EventNotFoundException(id);
            }
            return eventById;
        }

        public async Task<IEnumerable<Event>> GetAllForTimeLine(int userId)
        {
            return await _dbContext.Events
                .Where(e => e.EventUsers.Any(x => x.UserId == userId))
                .Where(e => e.AllowGuests)
                .Include(e => e.Groups)
                .Include(e => e.Topics)
                .Include(e => e.Posts)
                .ThenInclude(p => p.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetUserSuggestedEventsByUserId(int id)
        {
            var EventsList = new List<Event>();
            var FullUser = await _dbContext.Users
                .Where(x => x.Id == id)
                .Include(x => x.Topics)
                    .ThenInclude(x => x.Events)
                .Include(x => x.Groups)
                    .ThenInclude(x => x.Events)
                .ToListAsync();

            foreach (var user in FullUser)
            {
                foreach (var group in user.Groups)
                    foreach (var e in group.Events)
                        EventsList.Add(e);
                foreach (var topic in user.Topics)
                    foreach (var e in topic.Events)
                        EventsList.Add(e);
            }

            return EventsList;
        }
        public async Task<IEnumerable<Event>> GetEventsByTopic(int id)
        {
            var Events = await _dbContext.Topics
                .Where(x => x.Id == id)
                .Include(x => x.Events)
                .Select(x => x.Events.Where(e => e.AllowGuests == true))
                .SingleOrDefaultAsync();

            return Events;
        }
        public async Task<IEnumerable<Event>> GetEventsByGroup(int id)
        {
            var Events = await _dbContext.Groups
                .Where(x => x.Id == id)
                .Include(x => x.Events)
                .Select(x => x.Events.Where(e => e.AllowGuests == true))
                .SingleOrDefaultAsync();

            return Events;
        }
        public async Task<Event> Create(Event entity)
        {
            await _dbContext.Events.AddAsync(entity);
            await _dbContext.SaveChangesAsync();


            var newEvent = await _dbContext.Events
                .Include(e => e.EventUsers)
                .Include(e => e.Groups)
                .Include(e => e.Topics)
                .Where(e => e.Id == entity.Id)
                .FirstOrDefaultAsync();

            return newEvent;
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

        public async Task<Event> AddUserToEvent(int eventId, int userId)
        {
            var eventT = await _dbContext.Events.Include(x => x.EventUsers).Where(x => x.Id == eventId).FirstOrDefaultAsync();
            var user = await _dbContext.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

            var userEvent = new EventUser { EventId = eventId, UserId = userId };

            eventT.EventUsers.Add(userEvent);

            _dbContext.Entry(eventT).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return eventT;
        }
    }
}
