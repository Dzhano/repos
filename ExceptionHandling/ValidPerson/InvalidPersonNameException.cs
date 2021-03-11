using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ValidPerson
{
    public class InvalidPersonNameException : ArgumentNullException
    {
        public InvalidPersonNameException()
        {
        }

        public InvalidPersonNameException(string paramName) : base(paramName)
        {
        }

        public InvalidPersonNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidPersonNameException(string paramName, string message) : base(paramName, message)
        {
        }

        protected InvalidPersonNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
