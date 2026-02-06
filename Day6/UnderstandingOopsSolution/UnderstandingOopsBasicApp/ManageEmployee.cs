using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class ManageEmployee
    {
        Employee employee;//creating the refference
        public ManageEmployee()
        {
            employee = new Employee();//creating object for the reference
        }
        public void CreateEmployee()
        {
            Console.WriteLine("Please enter the employee Id");
            int id;
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for ID. Please try again");
            }
            employee.Id = id;
            Console.WriteLine("Please enter employee name");
            employee.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter the employee Date Of Birth(format - yyyy-mm-dd)");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter employee salary");
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
        }
        public void DisplayEmployee()
        {
            Console.WriteLine($"Employee Id: {employee.Id}");
            Console.WriteLine($"Employee Name: {employee.Name}");
            Console.WriteLine($"Employee Date Of Birth: {employee.DateOfBirth}");
            Console.WriteLine($"Employee Salary: {employee.Salary}");
            Console.WriteLine($"Employee Department Id: {employee.Department.Id}");
            Console.WriteLine($"Employee Department Name: {employee.Department.Name}");
        }
    }
}
