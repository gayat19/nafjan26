namespace UnderstandingOopsBasicApp
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private int Age { get; set; }
        protected string Remarks { get; set; }
        public virtual void AssignValues()
        {
            Id = 100;
            Name = "Alice";
            Age = 20; // Accessible within the class
        }
    }
    class LongDistanceStudent : Student
    {
        public int Duration { get; set; }
            public override void AssignValues()
            {
                base.AssignValues();
                Duration = 100;
            }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           ManageEmployee manageEmployee = new ManageEmployee();
            //manageEmployee.CreateEmployee();
            manageEmployee.DisplayEmployee();
          }
    }
}
