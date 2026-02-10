using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class EmployeeRepositoryWithCollection : IRepository
    {
        List<Employee> employees = new List<Employee>();
        public bool Add(Employee employee)
        {
            int id = GenerateID();
            employee.Id = id;
            employees.Add(employee);
            return true;
        }

        private int GenerateID()
        {
            employees.Sort();
            if (employees.Count == 0)
            {
                return 1;
            }
            else
            {
                return employees[employees.Count - 1].Id + 1;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            var employee = GetEmployee(employeeId);
            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }
           return false;
        }

        public Employee[]? GetAllEmployees()
        {
            if(employees == null || employees.Count == 0)
            {
                return null;
            }
            else
            {
                return employees.ToArray();
            }
        }

        public Employee? GetEmployee(int employeeId)
        {
            var newEmpl = new Employee() { Id = employeeId};
            if(employees.Contains(newEmpl))
            {
                int index = employees.IndexOf(newEmpl);
                return employees[index];
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEmployee(int employeeId, Employee employee)
        {
            var oldEmployee = GetEmployee(employeeId);
            if (oldEmployee != null) 
             {
                oldEmployee.Name = employee.Name;
                oldEmployee.DateOfBirth = employee.DateOfBirth;
                oldEmployee.Department = employee.Department;
                oldEmployee.Salary = employee.Salary;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
