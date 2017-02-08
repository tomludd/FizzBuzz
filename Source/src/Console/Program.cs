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
            Console.WriteLine(Enumerable.Range(1, 100).Aggregate("", (workingSentence, next) => workingSentence += $"\n{(next % 15 == 0 ? "FizzBuzz" : next % 5 == 0 ? "Buzz" : next % 3 == 0 ? "Fizz" : next.ToString())}"));
            Console.ReadLine();
        }
    }
}
