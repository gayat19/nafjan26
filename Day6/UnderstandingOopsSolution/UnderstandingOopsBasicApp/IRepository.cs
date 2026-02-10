using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal interface IRepository
    {
        public bool Add(Employee employee);
        public Employee[]? GetAllEmployees();
        public bool UpdateEmployee(int employeeId, Employee employee);
        public bool DeleteEmployee(int employeeId);
        public Employee? GetEmployee(int employeeId);
    }
}
