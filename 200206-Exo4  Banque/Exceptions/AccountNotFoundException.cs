using System;
using System.Collections.Generic;
using System.Text;

namespace _200206_Exo4_Banque.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message)
        {
        }

        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AccountNotFoundException()
        {
        }
    }
}
