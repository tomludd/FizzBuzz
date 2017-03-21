using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Features.FizzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public IEnumerable<string> GetFizzBuzz(int count)
        {
            if(count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Value has to be 0 or higher");

            return Enumerable.Range(1, count).Select(x => x % 15 == 0 ? "FizzBuzz" : x % 5 == 0 ? "Buzz" : x % 3 == 0 ? "Fizz" : x.ToString());
        }
    }
}
