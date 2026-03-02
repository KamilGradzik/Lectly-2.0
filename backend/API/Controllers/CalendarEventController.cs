using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.CalendarEvent;
using backend.Application.Interfaces;
using backend.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{   
    [ApiController]
    [Route("api/calendar-events")]
    [Tags("Calendar Events")]
    public class CalendarEventController : ControllerBase
    {   
        private readonly ICalendarEventService _calendarEventService;
        public CalendarEventController(ICalendarEventService calendarEventService)
        {
            _calendarEventService = calendarEventService;
        }
        
        [Authorize]
        [Route("monthly-events")]
        [HttpGet]
        public async Task<IActionResult> GetMonthlyCalendarEventsAsync([FromQuery] int month, [FromQuery] int year)
        {
            var eventDtos = await _calendarEventService.GetUserMonthlyCalendarEventsAsync(month, year);
            return Ok(eventDtos);
        }

        [Authorize]
        [Route("create")]
        [HttpPost]
        public async Task <IActionResult> AddCalendarEventAsync([FromBody] CreateCalendarEventDto dto)
        {
            await _calendarEventService.AddCalendarEventAsync(dto);
            return Created();
        }

        [Authorize]
        [Route("update")]
        [HttpPatch]
        public async Task<IActionResult> UpdateCalendarEventAsync([FromBody] CalendarEventDto dto)
        {
            await _calendarEventService.UpdateCalendarEventAsync(dto);
            return Ok("Calendar evenet successfuly updated!");
        }

        [Authorize]
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> RemoveCalendarEventAsync([FromQuery] Guid Id)
        {
            await _calendarEventService.RemoveCalendarEventAsync(Id);
            return NoContent();
        }
    }
}