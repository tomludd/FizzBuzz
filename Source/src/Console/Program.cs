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
            //IFizzBuzzService fizzBuzzService = new FizzBuzzService(FizzBuzzService.Rules.FizzBuzzPopWhackZingChop);
            IFizzBuzzService fizzBuzzService = new FizzBuzzService(FizzBuzzService.Rules.FizzBuzz);

            foreach (var result in fizzBuzzService.GetFizzBuzz(100))
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
