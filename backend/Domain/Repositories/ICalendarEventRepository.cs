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
        Task<IReadOnlyList<CalendarEvent>> GetMonthlyCalendarEventsAsync(int month, int year, Guid userId);
        Task RemoveAsync(CalendarEvent calendarEvent);
    }
}