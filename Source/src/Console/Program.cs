using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFizzBuzzService fizzBuzzService = new FizzBuzzService();

            foreach (var result in fizzBuzzService.GetFizzBuzz(100))
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
