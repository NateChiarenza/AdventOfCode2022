using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.answers
{
    public interface IAdvent4Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class answer4 : IAdvent4Service
    {

        public answer4()
        {

        }



        public async Task<string> part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var rounds = Text.Split("\r\n");
                var total = 0;
                
                foreach (var pair in rounds)
                {
                    var assignments = pair.Split(",");
                    var assignment1 = assignments[0].Split("-");
                    var assignment2 = assignments[1].Split("-");
                    if(Int32.Parse(assignment1[0]) <= Int32.Parse(assignment2[0]) && Int32.Parse(assignment1[1]) >= Int32.Parse(assignment2[1]))
                    {
                        total++;
                        continue;
                    }
                    if (Int32.Parse(assignment2[0]) <= Int32.Parse(assignment1[0]) && Int32.Parse(assignment2[1]) >= Int32.Parse(assignment1[1]))
                    {
                        total++;
                        continue;
                    }
                }

                return total.ToString();
            }
        }
        public async Task<string> part2(IFormFile input)
        {
            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var rounds = Text.Split("\r\n");
                var total = 0;

                foreach (var pair in rounds)
                {
                    var assignments = pair.Split(",");
                    var assignment1 = assignments[0].Split("-");
                    var assignment2 = assignments[1].Split("-");
                    if (Int32.Parse(assignment1[0]) <= Int32.Parse(assignment2[0]) && Int32.Parse(assignment1[1]) >= Int32.Parse(assignment2[0]))
                    {
                        total++;
                        continue;
                    }
                    if (Int32.Parse(assignment2[0]) <= Int32.Parse(assignment1[0]) && Int32.Parse(assignment2[1]) >= Int32.Parse(assignment1[0]))
                    {
                        total++;
                        continue;
                    }
                }

                return total.ToString();
            }
        }
    }
}
