namespace HrAppModelLibrary
{
    public class Employee : IComparable<Employee>, IEquatable<Employee>
    {
        //prop - properties
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime DateOfBirth { get; set; }

        public Department Department { get; set; }

        public float Salary { get; set; }

        //ctor- Constructor
        public Employee()
        {
            Department = new Department();
        }

        public Employee(int id, string name, DateTime dateOfBirth, float salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Employee Id: {Id}\nEmployee Name: {Name}\nEmployee Date Of Birth: {DateOfBirth}\nEmployee Salary: {Salary}\nEmployee Department Id: {Department.Id}\nEmployee Department Name: {Department.Name}";
        }

        public int CompareTo(Employee? other)
        {
            return this.Id.CompareTo(other?.Id);
        }

        public bool Equals(Employee? other)
        {
            return this.Id == other?.Id;
        }
    }
}
