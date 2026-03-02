using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;
using backend.Application.DTOs.CalendarEvent;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using backend.Entities;

namespace backend.Application.Services
{
    public class CalendarEventService : ICalendarEventService
    {
        private readonly ICurrentUserService _currentUser;
        private readonly ICalendarEventRepository _calendarEventRepo;
        private readonly IUnitOfWork _unitRepo;

        public CalendarEventService(ICalendarEventRepository calendarEventRepo, IUnitOfWork unitRepo, ICurrentUserService currentUser)
        {
            _calendarEventRepo = calendarEventRepo;
            _unitRepo = unitRepo;
            _currentUser = currentUser;
        }

        public async Task AddCalendarEventAsync(CreateCalendarEventDto dto)
        {
            await _calendarEventRepo.AddAsync(new CalendarEvent(dto.Name, dto.BeginDate, dto.EndDate, dto.Type, _currentUser.UserId, dto.Desc));
            await _unitRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<CalendarEventDto>> GetUserMonthlyCalendarEventsAsync(int month, int year)
        {   
            var calendarEvents = await _calendarEventRepo.GetMonthlyCalendarEventsAsync(month, year, _currentUser.UserId);
            var userCalendarEvents = new List<CalendarEventDto>();

            foreach(var calendarEvent in calendarEvents)
            {
                userCalendarEvents.Add(new CalendarEventDto
                {
                    Id = calendarEvent.Id,
                    Name = calendarEvent.Name,
                    Desc = calendarEvent.Desc,
                    BeginDate = calendarEvent.BeginDate,
                    EndDate = calendarEvent.EndDate,
                    Type = calendarEvent.Type,
                });
            }

            return userCalendarEvents;
        }
        
        public async Task UpdateCalendarEventAsync(CalendarEventDto dto)
        {
            var calendarEvent = await _calendarEventRepo.GetAsync(dto.Id);
            if(calendarEvent == null)
                throw new NotFoundException("Cannot find calendar event with specified Id!");

            if(calendarEvent.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified calendar event!");
            
            calendarEvent.Rename(dto.Name);
            calendarEvent.UpdateDescription(dto.Desc);
            calendarEvent.Reschedule(dto.BeginDate, dto.EndDate);
            calendarEvent.ChangeType(dto.Type);

            await _unitRepo.SaveChangesAsync();
        }

        public async Task RemoveCalendarEventAsync(Guid calendarEventId)
        {
            var calendarEvent = await _calendarEventRepo.GetAsync(calendarEventId);
            if(calendarEvent == null)
                throw new NotFoundException("Cannot find calendar event with specified Id!");

            if(calendarEvent.OwnerUserId != _currentUser.UserId)
                throw new UnauthorizedException("Unauthorized access to specified calendar event!");

            await _calendarEventRepo.RemoveAsync(calendarEvent);
            await _unitRepo.SaveChangesAsync();
        }
    }
}