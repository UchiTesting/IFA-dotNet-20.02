using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _200225_Exo18_Monopoly.Exceptions
{
    class FundTransferException : Exception
    {
        public FundTransferException()
        {
        }

        public FundTransferException(string message) : base(message)
        {
        }

        public FundTransferException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FundTransferException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
