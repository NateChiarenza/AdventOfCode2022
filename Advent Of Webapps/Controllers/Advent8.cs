using Advent_Of_Webapps.answers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.Controllers
{
    [Route("api/advent8")]
    [ApiController]
    public class Advent8 : ControllerBase
    {
        private readonly IAdvent8Service _advent8;

        public Advent8(IAdvent8Service a)
        {
            _advent8 = a;
        }

        [HttpPost("Part1")]
        public async Task<IActionResult> part1(IFormFile input)
        {
            var result = await _advent8.part1(input);
            return Ok(result);
        }
        [HttpPost("Part2")]
        public async Task<IActionResult> part2(IFormFile input)
        {
            var result = await _advent8.part2(input);
            return Ok(result);
        }

    }
}
