using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class FizzBuzzServiceController : Controller
    {
        private readonly IFizzBuzzService FizzBuzzService;

        public FizzBuzzServiceController(IFizzBuzzService _fizzBuzzService)
        {
            FizzBuzzService = _fizzBuzzService;
        }
        
        // GET api/fizzbuzzservice/100
        [HttpGet("{count}")]
        public IEnumerable<string> Get(int count)
        {
            return FizzBuzzService.GetFizzBuzz(count);
        }
    }
}
