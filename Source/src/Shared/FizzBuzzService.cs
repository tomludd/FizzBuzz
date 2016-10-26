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
            SetRules(Rules.FizzBuzz);
        }

        public FizzBuzzService(Rules rules)
        {
            SetRules(rules);
        }

        public FizzBuzzService(IEnumerable<Fuzzier> customRules)
        {
            fuzziness.AddRange(customRules);
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

        public enum Rules
        {
            FizzBuzz,
            FizzBuzzPop,
            FizzBuzzPopWhack,
            FizzBuzzPopWhackZing,
            FizzBuzzPopWhackZingChop,
        }

        private void SetRules(Rules rules)
        {
            //Set default rules
            fuzziness.Add(new Fuzzier { Text = "Fizz", Value = 3 });
            fuzziness.Add(new Fuzzier { Text = "Buzz", Value = 5 });
            

            if (rules >= Rules.FizzBuzzPop)
                fuzziness.Add(new Fuzzier { Text = "Pop", Value = 7 });

            if (rules >= Rules.FizzBuzzPopWhack)
                fuzziness.Add(new Fuzzier { Text = "Whack", Value = 11 });

            if (rules >= Rules.FizzBuzzPopWhackZing)
                fuzziness.Add(new Fuzzier { Text = "Zing", Value = 8 });

            if (rules >= Rules.FizzBuzzPopWhackZingChop)
                fuzziness.Add(new Fuzzier { Text = "Chop", Value = 13 });
        }

        public class Fuzzier
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
    }
}
