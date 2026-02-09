using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class ManageEmployeeString : ManageEmployee
    {
        override public void DisplayEmployee()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Manage Employee Child");
            Console.WriteLine("---------------------------");
            Console.WriteLine(employee);
            Console.WriteLine("---------------------------");
        }
    }
}
