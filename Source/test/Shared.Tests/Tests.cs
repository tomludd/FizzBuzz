using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using Xunit;
using System.Diagnostics;

namespace Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(33)]
        [InlineData(100)]
        public void ReturnIEnumerableStringIfPositive(int value) 
        {
            IFizzBuzzService service = new FizzBuzzService();
            
            var result = service.GetFizzBuzz(value).ToList();
            
            var resultCount = result.Count;
            Assert.True(resultCount > 0 ? resultCount == value : resultCount == 0);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(33)]
        [InlineData(100)]
        public void AddOwnArgumentsToFizzBuzzServiceConstructor(int value)
        {
            var args = new List<FizzBuzzService.Fuzzier>
            {
                new FizzBuzzService.Fuzzier { Text = "Fuzz", Value = 4 },
                new FizzBuzzService.Fuzzier { Text = "Bizz", Value = 2 }
            };

            IFizzBuzzService service = new FizzBuzzService(args);

            var result = service.GetFizzBuzz(value).ToList();

            var resultCount = result.Count;
            Assert.True(resultCount > 0 ? resultCount == value : resultCount == 0);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(33)]
        [InlineData(100)]
        public void AddOwnArgumentsToFizzBuzzServiceConstructorCheckContents(int value)
        {
            

            var args = new List<FizzBuzzService.Fuzzier>
            {
                new FizzBuzzService.Fuzzier { Text = "Fuzz", Value = 4 },
                new FizzBuzzService.Fuzzier { Text = "Bizz", Value = 2 }
            };

            IFizzBuzzService service = new FizzBuzzService(args);

            var result = service.GetFizzBuzz(value).ToList();

            foreach(var arg in args)
            {
                var expectedValue = value > 0 ? value / arg.Value : 0;

                var countOfFuzzier = result.Where(x => x.Contains(arg.Text)).Count();
                
                Assert.True(countOfFuzzier == expectedValue, 
                    "The number of Fuzzier.Text does not match occurence ratio set by Value");
            }
        }
    }
}
