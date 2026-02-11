using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Exceptions
{
    public class NoItemsInCollectionException : Exception
    {
        private string message;
        public NoItemsInCollectionException() 
        {
            message = "No items in the collection";
        }
        public NoItemsInCollectionException(string collectionName)
        {
            message = $"No items in the {collectionName} collection";
        }
        override public string Message => message;

    }
}
