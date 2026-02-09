
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class ManageEmployeeWithRepo
    {
        EmployeeRepository employeeRepository;
        public ManageEmployeeWithRepo()
        {
            employeeRepository = new EmployeeRepository();
        }
        
        public void AddEmployees()
        {
            int choice = 0;
            do
            {
                Employee employee = TakeEmployeeDetailsFromConsole();
                if(employeeRepository.Add(employee))
                    Console.WriteLine("Employee Added");
                else
                    Console.WriteLine("Unable to add employee");

                Console.WriteLine("If you would like to add more employees?, please enter any number other than 0");
                while (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }
            }
            while (choice!=0);
        }

        private Employee TakeEmployeeDetailsFromConsole()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the employee name");
            employee.Name = Console.ReadLine()??"";
            Console.WriteLine("Please enter the employee Date Of Birth(format - yyyy-mm-dd)");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the employee salary");
            float salary;
            while (!Single.TryParse(Console.ReadLine(), out salary))
                Console.WriteLine("Invalid entry for salary. Please try again");
            employee.Salary = salary;
            Console.WriteLine("Please enter the departmnet ID");
            int did;
            while (!Int32.TryParse(Console.ReadLine(), out did))
                Console.WriteLine("Invalid ID. Please try again");
            employee.Department.Id = did;
            Console.WriteLine("Please enter the department name");
            employee.Department.Name = Console.ReadLine() ?? "Bench";
            return employee;
        }
        public void DisplayAllEmployees()
        {
            var employees = employeeRepository.GetAllEmployees();
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
            var employee = employeeRepository.GetEmployee(id);
            if (employee == null)
                Console.WriteLine("No such employee");
            else
                PrintEmployee(employee);
        }

        private void PrintEmployee(Employee employee)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine(employee);
            Console.WriteLine("----------------------------");
        }

        private int GetEmployeeIdFromConsole()
        {
            int id;
            Console.WriteLine("Please enter the employee ID");
            while (!Int32.TryParse(Console.ReadLine(),out id) || id<=0)
                Console.WriteLine("Invalid etry for Id. Please try again");
            return id;
        }

        public void UpdateEmployee()
        {
            int id = GetEmployeeIdFromConsole();
            var employee = employeeRepository.GetEmployee(id);
            if(employee == null)
            {
                Console.WriteLine("No such employee");
                return;
            }
            PrintEmployee(employee);
            Console.WriteLine("Please enter the updated details");
            var newEmployee = TakeEmployeeDetailsFromConsole();
            if (employeeRepository.UpdateEmployee(id, newEmployee))
                Console.WriteLine("Employee details updated successfully");
            else
                Console.WriteLine("Sorry. Unable to update at this moment");
        }
        public void DeleteEmployee()
        {
            int id = GetEmployeeIdFromConsole();
            var employee = employeeRepository.GetEmployee(id);
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
                if (employeeRepository.DeleteEmployee(id))
                {
                    Console.WriteLine("Employee deleted successfully");
                    return;
                }
            }
            Console.WriteLine("Delete cancelled...");
        }
    }
}
