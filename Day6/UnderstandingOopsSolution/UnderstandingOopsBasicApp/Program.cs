namespace UnderstandingOopsBasicApp
{
    
    internal class Program
    {
        //ManageEmployeeWithRepo manageEmployee = new ManageEmployeeWithRepo(new EmployeeRepositoryWithCollection());
        ManageEmployeeWithRepo manageEmployee = new ManageEmployeeWithTwoRepo
            (new EmployeeRepositoryWithCollection(), new DepartmnetRepository());
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display Employees");
            Console.WriteLine("3. Display Employee by Id");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
        }
        void PerformAction()
        {
            int choice = 6;
            do
            {
                PrintMenu();
                while(!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                }
                switch (choice)
                {
                    case 1:
                        manageEmployee.AddEmployees();
                        break;
                    case 2:
                        manageEmployee.DisplayAllEmployees();
                        break;
                    case 3:
                        manageEmployee.DisplaySingleEmployee();
                        break;
                    case 4:
                        manageEmployee.UpdateEmployee();
                        break;
                    case 5:
                        manageEmployee.DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the application");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
            }while(choice != 6);
        }
        static void Main(string[] args)
        {
            new Program().PerformAction();
        }
    }
}
