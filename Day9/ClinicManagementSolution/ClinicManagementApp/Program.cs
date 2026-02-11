namespace ClinicManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                Console.WriteLine("Please enter the first number");
				int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the second number");
                int num2 = Convert.ToInt32(Console.ReadLine());
                int result = num1 / num2;
                Console.WriteLine("The result is " + result);
                return;
            }
			catch (FormatException fe)
			{
                Console.WriteLine("The input was not a number");
                Console.WriteLine(fe.Message);
			}
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("The denominator cannot be zero");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Always gets executed");
            }
            Console.WriteLine("After catch");
        }
    }
}
