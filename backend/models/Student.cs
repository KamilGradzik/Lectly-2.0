using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string StudentCode { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string? AdditionalInfo { get; private set; }

        private Student() { }

        public Student(string studentCode, string firstName, string lastName, string? additionalInfo = null)
        {
            Id = new Guid();
            SetStudentCode(studentCode);
            SetStudentFirstName(firstName);
            SetStudentLastName(lastName);
            AdditionalInfo = additionalInfo;
        }

        public void SetStudentCode(string studentCode)
        {
            if(string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Student's code cannot be empty!");
            StudentCode = studentCode;
        } 

        public void SetStudentFirstName(string firstName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Student's first name cannot be empty!");
            FirstName = firstName;
        }

        public void SetStudentLastName(string lastName)
        {
            if(string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Student's last name cannet be empty!");
            LastName = lastName;
        } 
    }
}