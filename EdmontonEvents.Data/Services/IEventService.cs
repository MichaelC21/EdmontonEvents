using EdmontonEvents.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdmontonEvents.Data.Services
{
    public interface IEventService
    {
        Task<Event?> GetEventByID(int id);
    }
}
