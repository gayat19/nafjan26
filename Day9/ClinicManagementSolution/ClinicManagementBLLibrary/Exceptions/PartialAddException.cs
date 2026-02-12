using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class PartialAddException : Exception
    {
        public PartialAddException(string message) : base(message)
        {

        }
    }
}
