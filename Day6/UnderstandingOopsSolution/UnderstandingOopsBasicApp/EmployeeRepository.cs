using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class EmployeeRepository : IRepository
    {
        Employee[] employees;
        public EmployeeRepository()
        {
            Console.WriteLine("Please enter the number of employees you would like to have");
            int numberOfEmployees;
            while (!Int32.TryParse(Console.ReadLine(), out numberOfEmployees))
            {
                Console.WriteLine("Invalid entry for number of employees. Please try again");
            }
            employees = new Employee[numberOfEmployees];
        }
        public bool Add(Employee employee)
        {
            int newId = GenerateEmployeeId();
            if (newId == 0 || newId == -1)
            {
                Console.WriteLine("Unable to add employee");
                return false;
            } 
            employee.Id = newId;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = employee;
                    Console.WriteLine($"Employee with ID {employee.Id} added successfully.");
                    return true;
                }
            }
            Console.WriteLine("Unable to add employee at this moment");
            return false;
        }

        private int GenerateEmployeeId()
        {
            if (employees[0] == null)
                return 1;
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Employee Repository is full. Cannot add more employees.");
                return -1; // Indicating that the repository is full
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    return (employees[i-1].Id+ 1); 
                }
            }
            return 0;
        }
        public Employee[]? GetAllEmployees()
        {
            if(employees == null || employees.Length == 0 || employees[0] == null)
            {
                Console.WriteLine("No employees found in the repository.");
                return null; // Return an empty array if no employees are found
            }
            return employees;
        }
        public bool UpdateEmployee(int  employeeId, Employee employee)
        {
            var oldEmployeeIndex = GetEmployeeById(employeeId);
            if (oldEmployeeIndex == -1)
            {
                Console.WriteLine($"Employee with ID {employeeId} not found. Update failed.");
                return false;
            }
            if (employee != null)
            {
                employee.Id = employeeId;
                employees[oldEmployeeIndex] = employee??new Employee();
                Console.WriteLine("Employee details updated");
                return true;
            }
            return false;
        }
        public bool DeleteEmployee(int employeeId)
        {
            var employeeIndex = GetEmployeeById(employeeId);
            if (employeeIndex == -1)
            {
                Console.WriteLine($"Employee with ID {employeeId} not found. Deletion failed.");
                return false;
            }
            employees[employeeIndex] = null;
            if(employeeIndex < employees.Length)
                ReAllignArray(employeeIndex);

            Console.WriteLine($"Employee with ID {employeeId} deleted successfully.");
            return true;
        }
        private void ReAllignArray(int position)
        {
            for (int i = position; i < employees.Length - 1; i++)
            {
                employees[i] = employees[i + 1];
            }
                employees[employees.Length - 1] = null;
        }
        public Employee? GetEmployee(int employeeId)
        {
            var employeeIndex = GetEmployeeById(employeeId);
            if (employeeIndex == -1)
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
                return null;
            }
            return employees[employeeIndex];
        }

        private int GetEmployeeById(int employeeId)
        {
            if (employeeId <= 0)
                return -1;
            for(int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == employeeId)
                    return i;
            }
            return -1;
        }
    }
}
