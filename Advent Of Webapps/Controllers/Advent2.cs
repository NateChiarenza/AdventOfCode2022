using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advent_Of_Webapps.answers;
using Microsoft.AspNetCore.Http;

namespace Advent_Of_Webapps.Controllers
{
    [Route("api/advent2")]
    [ApiController]
    public class Advent2:ControllerBase
    {
        private readonly IAdvent2Service _advent2;

        public Advent2(IAdvent2Service a)
        {
            _advent2 = a;
        }

        [HttpPost("Part1")]
        public async Task<IActionResult> part1(IFormFile input)
        {
            var result = await _advent2.part1(input);
            return Ok(result);
        }
        [HttpPost("Part2")]
        public async Task<IActionResult> part2(IFormFile input)
        {
            var result = await _advent2.part2(input);
            return Ok(result);
        }

    }
}
