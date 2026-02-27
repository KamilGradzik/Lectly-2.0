using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Application.Common;

namespace backend.Entities
{
    public class GroupSubject
    {
        public Guid GroupId { get; private set; }
        public Guid SubjectId { get; private set; }

        private GroupSubject() {}
        
        public GroupSubject(Guid groupId, Guid subjectId)
        {
            if(groupId == Guid.Empty || subjectId == Guid.Empty)
                throw new ValidationException("Neither subject's Id or group's Id cannot be empty!");
            
            GroupId = groupId;
            SubjectId = subjectId;
        }
    }
}