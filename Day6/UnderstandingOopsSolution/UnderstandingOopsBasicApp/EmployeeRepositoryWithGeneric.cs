using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class EmployeeRepositoryWithGeneric : IRepo<int, Employee>
    {
        List<Employee> employees = new List<Employee>();
        public bool Add(Employee item)
        {
            int id = GenerateID();
            item.Id = id;
            employees.Add(item);
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

        public bool Delete(int key)
        {
            var employee = Get(key);
            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }
            return false;
        }

        public Employee? Get(int key)
        {
            var newEmpl = new Employee() { Id = key };
            if (employees.Contains(newEmpl))
            {
                int index = employees.IndexOf(newEmpl);
                return employees[index];
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Employee>? GetAll()
        {
            if (employees == null || employees.Count == 0)
            {
                return null;
            }
            else
            {
                return employees;
            }
        }

        public bool Update(int key, Employee item)
        {
            var oldEmployee = Get(key);
            if (oldEmployee != null)
            {
                oldEmployee.Name = item.Name;
                oldEmployee.DateOfBirth = item.DateOfBirth;
                oldEmployee.Department = item.Department;
                oldEmployee.Salary = item.Salary;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
