using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Enums;

namespace backend.Application.DTOs.CalendarEvent
{
    public class CreateCalendarEventDto
    {
        public string Name { get; set; } = null!;
        public string? Desc { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventType Type { get; set; }
    }
}