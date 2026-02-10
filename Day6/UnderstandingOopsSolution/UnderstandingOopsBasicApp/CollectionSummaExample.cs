using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class CollectionSummaExample
    {

        void UnderstandingList()
        {
            //List<int> numbers = new List<int> { 87,34,90,56,12 };
            //foreach (int number in numbers) 
            //    Console.WriteLine(number);
            //numbers.Sort();
            //Console.WriteLine("After sorting");
            //foreach (int number in numbers)
            //    Console.WriteLine(number);
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, Name = "John", DateOfBirth = new DateTime(1990, 5, 15), Salary=324323 });
            employees.Add(new Employee { Id = 2, Name = "Alice", DateOfBirth = new DateTime(1985, 8, 20), Salary = 45000 });
            foreach (Employee employee in employees)
                Console.WriteLine(employee);
            employees.Sort();
            Console.WriteLine("After sorting");
            foreach (Employee employee in employees)
                Console.WriteLine(employee);
            employees.Remove(new Employee { Id=1});
            Console.WriteLine("After remove");
            foreach (Employee employee in employees)
                Console.WriteLine(employee);
        }

        static void Main(string[] args)
        {
            new CollectionSummaExample().UnderstandingList();
        }
    }
}
