using Advent_Of_Webapps.answers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.Controllers
{
    [Route("api/advent5")]
    [ApiController]
    public class Advent5 : ControllerBase
    {
        private readonly IAdvent5Service _advent5;

        public Advent5(IAdvent5Service a)
        {
            _advent5 = a;
        }

        [HttpPost("Part1")]
        public async Task<IActionResult> part1(IFormFile input)
        {
            var result = await _advent5.part1(input);
            return Ok(result);
        }
        [HttpPost("Part2")]
        public async Task<IActionResult> part2(IFormFile input)
        {
            var result = await _advent5.part2(input);
            return Ok(result);
        }

    }
}
