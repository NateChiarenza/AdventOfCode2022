using Advent_Of_Webapps.answers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.Controllers
{
    [Route("api/advent4")]
    [ApiController]
    public class Advent4 : ControllerBase
    {
        private readonly IAdvent4Service _advent4;

        public Advent4(IAdvent4Service a)
        {
            _advent4 = a;
        }

        [HttpPost("Part1")]
        public async Task<IActionResult> part1(IFormFile input)
        {
            var result = await _advent4.part1(input);
            return Ok(result);
        }
        [HttpPost("Part2")]
        public async Task<IActionResult> part2(IFormFile input)
        {
            var result = await _advent4.part2(input);
            return Ok(result);
        }

    }
}
