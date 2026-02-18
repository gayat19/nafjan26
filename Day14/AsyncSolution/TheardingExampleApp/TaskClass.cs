using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheardingExampleApp
{
    internal class TaskClass
    {
        async Task<int> CalculateSum(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }
        public async static Task Main(string[] args)
        {
            
            TaskClass tc = new TaskClass();
            //Task<int> result = tc.CalculateSum(100);
            //Console.WriteLine(result.Result);
            int result = await tc.CalculateSum(100);
            Console.WriteLine(result);
        }
    }
}
