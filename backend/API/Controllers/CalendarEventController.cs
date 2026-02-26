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
    public class CalendarEventController : ControllerBase
    {   
        private readonly ICalendarEventService _calendarEventService;
        public CalendarEventController(ICalendarEventService calendarEventService)
        {
            _calendarEventService = calendarEventService;
        }
        
        [Authorize]
        [Route("monthly-events")]
        [HttpPost]
        public async Task<IActionResult> GetMonthlyEventsAsync(CreateCalendarEventDto dto)
        {
            try
            {
                Console.WriteLine(dto.Name);
                await _calendarEventService.AddCalendarEventAsync(dto);
                return Ok("Event added sucessfuly!");
            }
            catch(Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}