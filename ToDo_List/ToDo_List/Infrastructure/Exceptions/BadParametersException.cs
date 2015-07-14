using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo_List.Infrastructure.Exceptions
{
    public class BadParametersException : Exception
    {
        public BadParametersException(string message)
            : base(message)
        {
        }
    }
}