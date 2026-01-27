using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}