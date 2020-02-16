using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _200206_Exo4_Banque
{
    public class MoneyWithdrawExceedException : Exception
    {
        private new const string Message = "Withdrawal refused. The sum asked for exceeds the account balance.";

        public MoneyWithdrawExceedException() : base(Message) { }

        public MoneyWithdrawExceedException(string message) : base(message)
        {
        }

        public MoneyWithdrawExceedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MoneyWithdrawExceedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
