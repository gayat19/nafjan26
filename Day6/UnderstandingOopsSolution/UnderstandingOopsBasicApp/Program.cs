namespace UnderstandingOopsBasicApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManageEmployee manage = new ManageEmployee();
            manage.CreateEmployee();
            manage.DisplayEmployee();

        }
    }
}
