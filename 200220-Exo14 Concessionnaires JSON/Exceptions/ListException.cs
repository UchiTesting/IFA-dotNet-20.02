using System;
using System.Collections.Generic;
using System.Text;

namespace _200220_Exo14_Concessionnaires_JSON.Exceptions
{
    public class ListException : Exception
    {
        public ListException(string message) : base(message)
        {
        }

        public ListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ListException()
        {
        }

    }
}
