using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.Common
{
    public class NotFoundException(string Message) : Exception(Message) {}

    public class UnauthorizedException(string Message) : Exception(Message) {}
    
    public class ValidationException(string Message) : Exception(Message) {}
}