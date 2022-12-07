using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.answers
{
    public interface IAdvent6Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class answer6 : IAdvent6Service
    {

        public answer6()
        {

        }



        public async Task<string> part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();

                var Input = new List<char>();
                Input.AddRange(Text.ToCharArray());
                var index = 0;
                var key = new List<char>();
                foreach (var letter in Input)
                {
                    if (!key.Contains(letter))
                    {
                        key.Add(letter);
                        index++;
                        if (key.Count == 4)
                        {
                            break;
                        }
                        continue;
                    }
                    while (key.Contains(letter))
                    {
                        key.RemoveAt(0);
                    }
                    key.Add(letter);
                    index++;
                }
                return index.ToString();
            }
        }

        public async Task<string> part2(IFormFile input)
        {
            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();

                var Input = new List<char>();
                Input.AddRange(Text.ToCharArray());
                var index = 0;
                var key = new List<char>();
                foreach (var letter in Input)
                {
                    if (!key.Contains(letter))
                    {
                        key.Add(letter);
                        index++;
                        if (key.Count == 14)
                        {
                            break;
                        }
                        continue;
                    }
                    while (key.Contains(letter))
                    {
                        key.RemoveAt(0);
                    }
                    key.Add(letter);
                    index++;
                }
                return index.ToString();
            }
        }
    }
}

