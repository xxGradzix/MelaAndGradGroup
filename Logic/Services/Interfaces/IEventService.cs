using Data.API.Entities;
using System;
using System.Collections.Generic;

namespace Logic.Services.Interfaces
{
    public interface IEventService
    {
        bool AddEvent(IEvent eventBase);
        List<IEvent> GetAllEvents();
    }
}
