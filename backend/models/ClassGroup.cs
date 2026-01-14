using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class ClassGroup
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Desc { get; private set; }

        private ClassGroup() { }

        public ClassGroup(string name, string? desc = null)
        {
            Id = new Guid();
            SetClassGroupName(name);
            Desc = desc;
        }
        
        public void SetClassGroupName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Class group name cannot be empty!");
            Name = name;
        }
    }
}