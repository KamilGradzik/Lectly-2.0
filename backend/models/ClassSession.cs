using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class ClassSession
    {
        public Guid Id { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public string Classroom { get; private set; } = null!;

        private ClassSession() { }

        public ClassSession(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime, string classroom)
        {
            Id = new Guid();
            DayOfWeek = dayOfWeek;
            SetClassTime(startTime, endTime);
            SetClassroom(classroom);
            
        }

        public void SetClassTime(TimeOnly startTime, TimeOnly endTime)
        {
            if(startTime >= endTime)
                throw new ArgumentException("Class cannot end before it starts!");

            StartTime = startTime;
            EndTime = endTime;
        }

        public void SetClassroom(string classroom)
        {
            if(string.IsNullOrWhiteSpace(classroom))
                throw new ArgumentException("Classroom cannot be empty!");
        }
        
    }
}