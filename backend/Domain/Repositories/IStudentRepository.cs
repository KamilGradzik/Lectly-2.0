using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task<Student> GetAsync(Guid id);
        Task<IReadOnlyList<Student>> GetGroupStudentsAsync(Guid groupId);
        Task RemoveAsync(Student student);
    }
}