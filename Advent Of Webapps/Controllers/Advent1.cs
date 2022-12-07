using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advent_Of_Webapps.answers;
using Microsoft.AspNetCore.Http;

namespace Advent_Of_Webapps.Controllers
{
    [Route("api/advent1")]
    [ApiController]
    public class Advent1 : ControllerBase
    {
        private readonly IAdvent1Service _advent1;

        public Advent1(IAdvent1Service a)
        {
            _advent1 = a;
        }
      

        [HttpPost("Part1")]
        public async Task<IActionResult> part1(IFormFile input)
        {
            var result = await _advent1.part1(input);
            return Ok(result);
        }
        [HttpPost("Part2")]
        public async Task<IActionResult> part2(IFormFile input)
        {
            var result = await _advent1.part2(input);
            return Ok(result);
        }
    }
}
