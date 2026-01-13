using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class Subject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Desc { get; private set; }

        private Subject() {}

        public Subject(string name, string? desc = null)
        {
            Id = Guid.NewGuid();
            SetSubjectName(name);
            Desc = desc;
        }

        public void SetSubjectName(string subjectName)
        {
            if(string.IsNullOrWhiteSpace(subjectName))
                throw new ArgumentException("Subject name cannot be empty!");
            Name = subjectName;
        }
    }
}