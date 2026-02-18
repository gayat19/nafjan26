using System;

namespace ThreadingExampleApp
{
    internal class Program
    {

         void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                
                Console.WriteLine(i+" "+Thread.CurrentThread.Name);
                Thread.Sleep(500);
            }
            lock(this)
            {
                for (int i = 10; i < 100; i = i + 10)
                {
                    Console.WriteLine(i + " " + Thread.CurrentThread.Name);
                    Thread.Sleep(500);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            Thread t1 = new Thread(p.PrintNumbers);
            Thread t2 = new Thread(p.PrintNumbers);
            t1.Name = "Thread 1";
            t2.Name = "Thread 2";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread start");
        }
    }
}