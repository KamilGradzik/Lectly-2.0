using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum EventType
{
    Exam,
    Meeting,
    FieldTrip,
    Event,
    Deadline,
    Other,
}

namespace backend.models
{
    public class CalendarEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Desc { get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public EventType Type { get; private set; }

        private CalendarEvent() {}

        public CalendarEvent(string name, DateTime beginDate, DateTime endDate, EventType type, string? desc = null)
        {
            Id = new Guid();
            SetName(name);
            Desc = desc;
            SetDateRange(beginDate, endDate);
            Type = type;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Calendar event's name cannot be empty!");
            Name = name;
        }

        public void SetDateRange(DateTime beginDate, DateTime endDate)
        {
            if(endDate < beginDate)
                throw new ArgumentException("Calendar event cannot end before it starts!");
            BeginDate = beginDate;
            EndDate = endDate;
        }
    }
}