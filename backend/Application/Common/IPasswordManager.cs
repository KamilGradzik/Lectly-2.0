using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.Common
{
    public interface IPasswordManager
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}