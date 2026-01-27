using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string StudentCode { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string? AdditionalInfo { get; private set; }
        public Guid GroupId { get; private set; }

        private Student() { }

        public Student(string studentCode, string firstName, string lastName, Guid groupId, string? additionalInfo = null)
        {
            Id = Guid.NewGuid();
            AssignStudentCode(studentCode);
            UpdateFirstName(firstName);
            UpdateLastName(lastName);
            UpdateAdditionalInfo(additionalInfo);
            AssignGroup(groupId);
        }

        public void AssignStudentCode(string studentCode)
        {
            if(string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Student's code cannot be empty!");
            StudentCode = studentCode;
        } 

        public void UpdateFirstName(string firstName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Student's first name cannot be empty!");
            FirstName = firstName;
        }

        public void UpdateLastName(string lastName)
        {
            if(string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Student's last name cannet be empty!");
            LastName = lastName;
        } 

        public void UpdateAdditionalInfo(string? additionalInfo = null)
        {
            AdditionalInfo = additionalInfo;
        }

        public void AssignGroup(Guid groupId)
        {
            if(groupId == Guid.Empty)
                throw new ArgumentException("Group's Id cannot be empty!");
            
            GroupId = groupId;
        }
    }
}