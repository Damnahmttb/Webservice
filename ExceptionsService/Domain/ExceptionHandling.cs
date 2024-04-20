using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsService.Domain
{
    public class ExceptionHandling : Exception
    {
        public ExceptionHandling(string message) : base(message) { }
    }
    public class NotFoundEception : ExceptionHandling
    {
        public NotFoundEception(string message) : base(message) { }
    }
    public class CoreException : ExceptionHandling
    {
        public CoreException(string message) : base(message) { }
    }
    public class CriticalUserException : ExceptionHandling
    {
        public CriticalUserException(string message) : base(message) { }
    }
    public class UserLevelException : ExceptionHandling
    {
        public UserLevelException(string message) : base(message) { }
    }


}
