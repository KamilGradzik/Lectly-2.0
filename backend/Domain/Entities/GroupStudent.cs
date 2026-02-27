using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;

namespace backend.Domain.Entities
{
    public class GroupStudent
    {
        public Guid GroupId { get; private set; }
        public Guid StudentId { get; private set; }

        private GroupStudent() {}
        
        public GroupStudent(Guid groupId, Guid studentId)
        {
            if(groupId == Guid.Empty || studentId == Guid.Empty)
                throw new ValidationException("Neither student's Id or group's Id cannot be empty!");
            
            GroupId = groupId;
            StudentId = studentId;
        }
        
    }
}