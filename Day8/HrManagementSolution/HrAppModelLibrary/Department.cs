using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrAppModelLibrary
{
    public class Department : IComparable<Department>, IEquatable<Department>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Employee[]? Employees { get; set; }

        public Department()
        {
            Employees = new Employee[3];
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return "Department Id: " + Id + "\nDepartment Name: " + Name;
        }

        public int CompareTo(Department? other)
        {
            return this.Id.CompareTo(other?.Id);
        }

        public bool Equals(Department? other)
        {
            return this.Id == other?.Id;
        }
    }
}
