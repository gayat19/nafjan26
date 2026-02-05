namespace FirstApp
{
    internal class Program
    {
        
        static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"The number in position {i+1} is: {numbers[i]}");
            }
        }
        static void UnderstandingMultiDimentionArray()
        {
            string[,] names = new string[2, 3] { 
                { "John", "Jane", "Doe" }, 
                { "Alice", "Bob", "Charlie" } 
            };
            for (int i = 0; i < names.GetLength(0); i++)
            {
                for (int j = 0; j < names.GetLength(1); j++)
                {
                    Console.WriteLine($"Name at position [{i},{j}] is: {names[i, j]}");
                }
            }   
        }
        static void UnderstandingJaggedArray()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5,90 };
            jaggedArray[2] = new int[] { 6, 7, 8 };
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Row {i}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void TakeNumbersFromUser()
        {
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter the {i+1} position number");
                while(!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            PrintNumbers(numbers);
        }
        static void Main(string[] args)
        {
            UnderstandingMultiDimentionArray();
        }
    }
}
