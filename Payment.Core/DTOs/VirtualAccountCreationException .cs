using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.DTOs
{
    public class VirtualAccountCreationException : Exception
    {
        // Constructor that only takes a message
        public VirtualAccountCreationException(string message) : base(message) { }

        // Constructor that takes a message and an inner exception
        public VirtualAccountCreationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
