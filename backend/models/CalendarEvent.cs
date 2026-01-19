using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public enum EventType
    {
        Exam,
        Meeting,
        FieldTrip,
        Event,
        Deadline,
        Other,
    }
    public class CalendarEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Desc { get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public EventType Type { get; private set; }
        public Guid OwnerUserId { get; private set; }

        private CalendarEvent() {}

        public CalendarEvent(string name, DateTime beginDate, DateTime endDate, EventType type, Guid ownerUserId, string? desc = null)
        {
            Id = Guid.NewGuid();
            Rename(name);
            UpdateDescription(desc);
            Reschedule(beginDate, endDate);
            ChangeType(type);
            
            if(ownerUserId == Guid.Empty)
                throw new ArgumentException("Owner's Id cannot be empty!");

            OwnerUserId = ownerUserId;
        }

        public void Rename(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Calendar event's name cannot be empty!");
            Name = name;
        }

        public void Reschedule(DateTime beginDate, DateTime endDate)
        {
            if(endDate < beginDate)
                throw new ArgumentException("Calendar event cannot end before it starts!");
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public void UpdateDescription(string? desc = null)
        {
            Desc = desc;
        }

        public void ChangeType(EventType type)
        {
            Type = type;
        }
    }
}