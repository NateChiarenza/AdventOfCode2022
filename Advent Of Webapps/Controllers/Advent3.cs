using Advent_Of_Webapps.answers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.Controllers
{
    [Route("api/advent3")]
    [ApiController]
    public class Advent3 : ControllerBase
    {
        private readonly IAdvent3Service _advent3;

        public Advent3(IAdvent3Service a)
        {
            _advent3 = a;
        }

        [HttpPost("Part1")]
        public async Task<IActionResult> part1(IFormFile input)
        {
            var result = await _advent3.part1(input);
            return Ok(result);
        }
        [HttpPost("Part2")]
        public async Task<IActionResult> part2(IFormFile input)
        {
            var result = await _advent3.part2(input);
            return Ok(result);
        }

    }
}
