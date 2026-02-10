using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class ManageEmployeeWithTwoRepo : ManageEmployeeWithRepo
    {
        readonly IRepo<int, Department> _departmentRepository;
        public ManageEmployeeWithTwoRepo(IRepository employeeRepository, 
            IRepo<int, Department> departmentRepository)
            : base(employeeRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public override void AddEmployees()
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
        protected override Employee TakeEmployeeDetailsFromConsole()
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
            while (!Int32.TryParse(Console.ReadLine(), out depId) )
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
        
    }
}
