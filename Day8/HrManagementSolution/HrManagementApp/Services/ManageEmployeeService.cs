using HrAppModelLibrary;
using HrManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagementApp.Services
{
    public class ManageEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;
        readonly IRepository<int, Department> _departmentRepository;
        public ManageEmployeeService(IRepository<int, Employee> employeeRepository,
            IRepository<int, Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public virtual void AddEmployees()
        {
            int choice = 0;
            do
            {
                Employee employee = TakeEmployeeDetailsFromConsole();
                if (_employeeRepository.Add(employee))
                    Console.WriteLine("Employee Added");
                else
                    Console.WriteLine("Unable to add employee");

                Console.WriteLine("If you would like to add more employees?, please enter any number other than 0");
                while (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }
            }
            while (choice != 0);
        }

        protected virtual Employee TakeEmployeeDetailsFromConsole()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the employee name");
            employee.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter the employee Date Of Birth(format - yyyy-mm-dd)");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the employee salary");
            float salary;
            while (!Single.TryParse(Console.ReadLine(), out salary))
                Console.WriteLine("Invalid entry for salary. Please try again");
            employee.Salary = salary;
            employee.Department = GetDepartmnetForEmployee();
            return employee;
        }
        private Department? GetDepartmnetForEmployee()
        {
            var departments = _departmentRepository.GetAll();
            if (departments == null || departments.Count() == 0)
            {
                Console.WriteLine("No department found. Please add a department first");
                var department = TakeDepartmnetDetailsFromConsole();

                _departmentRepository.Add(department);
                return department;
            }
            Console.WriteLine("Please select the department for employee from below list");
            foreach (var department in departments)
            {
                Console.WriteLine(department);
            }
            int depId;
            while (!Int32.TryParse(Console.ReadLine(), out depId))
            {
                Console.WriteLine("Invalid entry for department. Please try again");
            }
            var dept = _departmentRepository.Get(depId);
            if (dept == null)
            {
                Console.WriteLine("No department found. Please add a department first");
                var department = TakeDepartmnetDetailsFromConsole();

                _departmentRepository.Add(department);
                return department;
            }
            return dept;
        }
        private Department TakeDepartmnetDetailsFromConsole()
        {
            Department department = new Department();
            Console.WriteLine("Please enter the department name");
            department.Name = Console.ReadLine() ?? "";
            return department;
        }
        public void DisplayAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            if (employees == null)
            {
                Console.WriteLine("No employees found");
                return;
            }

            foreach (Employee item in employees)
            {
                PrintEmployee(item);
            }
        }
        public void DisplaySingleEmployee()
        {
            int id = GetEmployeeIdFromConsole();
            var employee = _employeeRepository.Get(id);
            if (employee == null)
                Console.WriteLine("No such employee");
            else
                PrintEmployee(employee);
        }

        protected void PrintEmployee(Employee employee)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine(employee);
            Console.WriteLine("----------------------------");
        }

        protected int GetEmployeeIdFromConsole()
        {
            int id;
            Console.WriteLine("Please enter the employee ID");
            while (!Int32.TryParse(Console.ReadLine(), out id) || id <= 0)
                Console.WriteLine("Invalid etry for Id. Please try again");
            return id;
        }

        public virtual void UpdateEmployee()
        {
            int id = GetEmployeeIdFromConsole();
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                Console.WriteLine("No such employee");
                return;
            }
            PrintEmployee(employee);
            Console.WriteLine("Please enter the updated details");
            var newEmployee = TakeEmployeeDetailsFromConsole();
            if (_employeeRepository.Update(id, newEmployee))
                Console.WriteLine("Employee details updated successfully");
            else
                Console.WriteLine("Sorry. Unable to update at this moment");
        }
        public void DeleteEmployee()
        {
            int id = GetEmployeeIdFromConsole();
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                Console.WriteLine("Unable to find employee for delete");
                return;
            }
            PrintEmployee(employee);
            Console.WriteLine("Are you sure you want to delete this employee?? yes/no");
            string choice = "no";
            choice = Console.ReadLine() ?? "no";
            if (choice.ToLower() == "yes")
            {
                if (_employeeRepository.Delete(id))
                {
                    Console.WriteLine("Employee deleted successfully");
                    return;
                }
            }
            Console.WriteLine("Delete cancelled...");
        }
    }
}
