using Advent_Of_Webapps.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Advent_Of_Webapps.answers
{
    public interface IAdvent1Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class answer1:IAdvent1Service
    {
        
        public answer1()
        {
            
        }

        

        async Task<string> IAdvent1Service.part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text =  await reader.ReadToEndAsync();
                var ElfArray = Text.Split("\r\n\r");
                var max = 0;
                
                foreach (var Elf in ElfArray)
                {
                    var temp = 0;
                    var Inventory = Elf.Split("\r\n");
                    foreach (var item in Inventory)
                    {
                        temp += Int32.Parse(item);
                    }
                    if (temp > max)
                    {
                        max = temp;
                    }
                }
                return max.ToString();
            }
        }
        public async Task<string> part2(IFormFile input)
        {
            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var ElfArray = Text.Split("\r\n\r");
                var max = 0;
                var totals = new List<int>();
                foreach (var Elf in ElfArray)
                {
                    var temp = 0;
                    var Inventory = Elf.Split("\r\n");
                    foreach (var item in Inventory)
                    {
                        temp += Int32.Parse(item);
                    }
                    totals.Add(temp);
                   
                }
                totals.Sort();
                max = totals[totals.Count-1] + totals[totals.Count-2] + totals[totals.Count-3];
                return max.ToString();
            }
        }
    }
}
