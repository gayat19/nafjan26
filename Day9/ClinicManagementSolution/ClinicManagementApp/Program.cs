namespace ClinicManagementApp
{
    internal class Program
    {
        //public delegate void MyDelegate(int num1,int num2);
        void Add(int num1, int num2)
        {
            Console.WriteLine($"The sum of {num1} and {num2} is {num1+num2}");
        }
        
        Program()
        {
            Action<int, int> del = Add;
            //del += delegate (int num1, int num2)//Anonymous method
            //{
            //    Console.WriteLine($"The product of {num1} and {num2} is {num1*num2}");
            //};
            del += (int num1, int num2)=>
                Console.WriteLine($"The product of {num1} and {num2} is {num1 * num2}");
            UseDelegate(del);
        }
        void UseDelegate(Action<int, int> del)
        {
            del(10, 20);

        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
