using System;
using BreakingNewsCore.Common.Models;

namespace BreakingNewsCore.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() : base()
        {
            
        }
        
        public AlreadyExistsException(string message)
            : base(message)
        {
        }

        public AlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AlreadyExistsException(Result result)
            : base($"Role {result.Errors} already exists in data base. ")
        {
        }
    }
}