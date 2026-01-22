using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class ClassSession
    {
        public Guid Id { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public string Classroom { get; private set; } = null!;
        public Guid GroupId { get; private set; }
        public Guid SubjectId { get; private set; }

        private ClassSession() { }

        public ClassSession(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime, string classroom, Guid groupId, Guid subjectId)
        {
            Id = Guid.NewGuid();
            ChangeDayOfWeek(dayOfWeek);
            UpdateClassTime(startTime, endTime);
            UpdateClassroom(classroom);
            AssignGroup(groupId);
            AssignSubject(subjectId);
        }

        public void UpdateClassTime(TimeOnly startTime, TimeOnly endTime)
        {
            if(startTime >= endTime)
                throw new ArgumentException("Class cannot end before it starts!");

            StartTime = startTime;
            EndTime = endTime;
        }

        public void UpdateClassroom(string classroom)
        {
            if(string.IsNullOrWhiteSpace(classroom))
                throw new ArgumentException("Classroom cannot be empty!");
        }
        
        public void ChangeDayOfWeek(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }

        public void AssignGroup(Guid groupId)
        {
            if(groupId == Guid.Empty)
                throw new ArgumentException("Group's Id cannot be empty!");
            
            GroupId = groupId;
        }

        public void AssignSubject(Guid subjectId)
        {
            if(subjectId == Guid.Empty)
                throw new ArgumentException("Subject's Id cannot be empty!");
            
            SubjectId = subjectId;
        }
    }
}