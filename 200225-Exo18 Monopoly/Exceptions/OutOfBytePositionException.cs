using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _200225_Exo18_Monopoly.Exceptions
{
    class OutOfBytePositionException : Exception
    {
        public OutOfBytePositionException()
        {
        }

        public OutOfBytePositionException(string message) : base(message)
        {
        }

        public OutOfBytePositionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfBytePositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
