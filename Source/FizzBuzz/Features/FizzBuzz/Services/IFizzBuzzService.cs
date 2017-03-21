using System;
using System.Collections.Generic;

namespace FizzBuzz.Features.FizzBuzz.Services
{
    public interface IFizzBuzzService
    {
        /// <summary>
        /// Gets a range of strings parsed with the rules in the FizzBuzz game.
        /// </summary>
        /// <param name="count"></param>
        /// <exception cref="ArgumentException">If paramsvalue is negative</exception>
        /// <returns></returns>
        IEnumerable<string> GetFizzBuzz(int count);
    }
}
