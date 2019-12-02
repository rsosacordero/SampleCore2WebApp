using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EF_WWT.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException()
        {
        }

        public ResourceNotFoundException(string message) : base(message)
        {
        }

        public ResourceNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
