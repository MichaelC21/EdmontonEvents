using EdmontonEvents.Data.Entities;
using EdmontonEvents.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdmontonEvents.Data.Services
{
    public class EventService: IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Event?> GetEventByID(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.EventID == id && e.Status == EventStatus.Published);
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
    }
}
