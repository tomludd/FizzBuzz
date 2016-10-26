using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class FizzBuzzService : IFizzBuzzService
    {

        private readonly List<Fuzzier> fuzziness = new List<Fuzzier>();

        public FizzBuzzService()
        {
            fuzziness.Add(new Fuzzier() { Text = "Fizz", Value = 3 });
            fuzziness.Add(new Fuzzier() { Text = "Buzz", Value = 5 });
        }

        public FizzBuzzService(IEnumerable<Fuzzier> Fuzzies)
        {
            fuzziness.AddRange(Fuzzies);
        }

        public IEnumerable<string> GetFizzBuzz(int count)
        {
            string output;
            for (int i = 1; i <= count; i++)
            {
                output = string.Empty;

                foreach (var fuzzie in fuzziness.Where(x => i % x.Value == 0))
                    output += fuzzie.Text;
                
                yield return string.IsNullOrEmpty(output) ? i.ToString() : output;
            }
        }

        public class Fuzzier
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
    }
}
