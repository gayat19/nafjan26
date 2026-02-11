using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        private string message;
        public ItemNotFoundException()
        {
            message = "Item not found";
        }
        public ItemNotFoundException( int id)
        {
            message = $" id {id} not found";
        }
        override public string Message => message;
    }
}
