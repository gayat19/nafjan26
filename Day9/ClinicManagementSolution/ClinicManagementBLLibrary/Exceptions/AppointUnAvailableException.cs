using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class AppointUnAvailableException : Exception
    {
        public AppointUnAvailableException() : base() { }
        public AppointUnAvailableException(string message) : base(message) { }
        public AppointUnAvailableException(string message, Exception innerException) : base(message, innerException) { }
    }
}
