using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Repositories;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Persistence.Repositories
{
    public class CalendarEventRepository : ICalendarEventRepository
    {
        private readonly AppDbContext _context;
        public CalendarEventRepository(AppDbContext context) { _context = context; }

        public async Task AddAsync(CalendarEvent calendarEvent)
        {
            _context.CalendarEvents.Add(calendarEvent);
        }

        public async Task<CalendarEvent?> GetAsync(Guid id)
        {
            return await _context.CalendarEvents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<CalendarEvent>> GetMonthlyCalendarEventsAsync(int month, int year, Guid userId)
        {
            return await _context.CalendarEvents.Where(x => x.BeginDate.Year == year && x.BeginDate.Month <= month && x.EndDate.Month >= month).ToListAsync();
        }

        public async Task RemoveAsync(CalendarEvent calendarEvent)
        {
            _context.CalendarEvents.Remove(calendarEvent);
        }
    
    }
}
