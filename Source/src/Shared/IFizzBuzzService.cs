using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public interface IFizzBuzzService
    {
        IEnumerable<string> GetFizzBuzz(int count);
    }
}
