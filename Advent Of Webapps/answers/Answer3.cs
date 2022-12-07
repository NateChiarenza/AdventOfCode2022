using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.answers
{
    public interface IAdvent3Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class answer3 : IAdvent3Service
    {

        public answer3()
        {

        }



        public async Task<string> part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var rounds = Text.Split("\r\n");
                var total = 0;

                foreach (var items in rounds)
                {
                    var temp1 = items.Substring(0, items.Length / 2);
                    var temp2 = items.Substring((items.Length / 2));
                    var a = temp2.ToCharArray();
                    foreach (var item in a)
                    {
                        if (temp1.Contains(item) && char.IsUpper(item))
                        {
                            total += item - 38;
                            break;
                        }
                        else if (temp1.Contains(item) && char.IsLower(item))
                        {
                            total += item - 96;
                            break;
                        }
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
                var groups = new List<string>();
                for (int i = 0; i < rounds.Length; i+= 3)
                {
                    groups.Add(rounds[i]);
                    groups.Add(rounds[i+1]);
                    groups.Add(rounds[i+2]);
                    var a = groups[0].ToCharArray();
                    foreach (var item in a)
                    {
                        if (groups[1].Contains(item) && groups[2].Contains(item) && char.IsUpper(item))
                        {
                            total += item - 38;
                            break;
                        }
                        else if (groups[1].Contains(item) && groups[2].Contains(item) && char.IsLower(item))
                        {
                            total += item - 96;
                            break;
                        }
                    }
                    groups.RemoveRange(0, 3);
                }
                return total.ToString();

            }
        }
    }
}
