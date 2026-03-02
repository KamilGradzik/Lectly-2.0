using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.CalendarEvent;
using backend.Entities;

namespace backend.Application.Interfaces
{
    public interface ICalendarEventService
    {
        Task AddCalendarEventAsync(CreateCalendarEventDto dto);
        Task <IReadOnlyList<CalendarEventDto>> GetUserMonthlyCalendarEventsAsync(int month, int year);
        Task UpdateCalendarEventAsync(CalendarEventDto dto);
        Task RemoveCalendarEventAsync(Guid clanedarEvnetId);
    }
}