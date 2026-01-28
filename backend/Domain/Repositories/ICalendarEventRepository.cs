using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface ICalendarEventRepository
    {
        Task AddAsync(CalendarEvent calendarEvent);
        Task<CalendarEvent?> GetAsync(Guid id);
        Task<IReadOnlyList<CalendarEvent>> GetMonthlyCalendarEventsAsync(Guid userId, int month, int year);
        Task RemoveAsync(CalendarEvent calendarEvent);
    }
}