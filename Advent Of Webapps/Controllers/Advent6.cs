using Advent_Of_Webapps.answers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.Controllers
{
    [Route("api/advent6")]
    [ApiController]
    public class Advent6 : ControllerBase
    {
        private readonly IAdvent6Service _advent6;

        public Advent6(IAdvent6Service a)
        {
            _advent6 = a;
        }

        [HttpPost("Part1")]
        public async Task<IActionResult> part1(IFormFile input)
        {
            var result = await _advent6.part1(input);
            return Ok(result);
        }
        [HttpPost("Part2")]
        public async Task<IActionResult> part2(IFormFile input)
        {
            var result = await _advent6.part2(input);
            return Ok(result);
        }

    }
}
