using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;

namespace backend.Entities
{
    public class ClassGroup
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Desc { get; private set; }
        public Guid OwnerUserId { get; private set; }

        private ClassGroup() { }

        public ClassGroup(string name, Guid ownerUserId, string? desc = null)
        {
            Id = Guid.NewGuid();
            Rename(name);
            UpdateDescription(desc);

            if(ownerUserId == Guid.Empty)
                throw new ValidationException("Owner's Id cannot be empty!");
            
            OwnerUserId = ownerUserId;
        }
        
        public void Rename(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Class group's name cannot be empty!");
            Name = name;
        }

        public void UpdateDescription(string? desc = null)
        {
            Desc = desc;
        }
    }
}