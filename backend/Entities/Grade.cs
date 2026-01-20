using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Grade
    {
        public Guid Id { get; private set; }
        public int Value { get; private set; }
        public decimal Weight { get; private set; }
        public string Desc { get; private set; } = null!;
        public DateTime DateIssued { get; private set; }
        public Guid SubjectId { get; private set; }
        public Guid StudentId { get; private set; }

        private Grade() { } 
        
        public Grade(int value, decimal weight, string desc, Guid subjectId, Guid studentId)
        {
            Id = new Guid();
            SetValue(value);
            SetWeight(weight);
            UpdateDescription(desc);
            AssignSubject(subjectId);
            AssignStudent(studentId);
            DateIssued = DateTime.Now;
        }

        public void SetValue(int value)
        {
            if(value > 0)
                Value = value;
            else throw new ArgumentException("Grade's value must be greater than 0!");
        }
        
        public void SetWeight(decimal weight)
        {
            if(weight > 0)
                Weight = weight;
            else throw new ArgumentException("Grade's weight must be greater than 0!");
        }

        public void UpdateDescription(string desc)
        {
            if(string.IsNullOrWhiteSpace(desc))
                throw new ArgumentException("Grade's description cannot be null!");
            Desc = desc;
        }

        public void AssignSubject(Guid subjectId)
        {
            if(subjectId == Guid.Empty)
                throw new ArgumentException("Subject's Id cannot be empty!");
            
            SubjectId = subjectId;
        }

        public void AssignStudent(Guid studentId)
        {
            if(studentId == Guid.Empty)
                throw new ArgumentException("Student's Id cannot be empty!");
            
            StudentId = studentId;
        }
    }
}