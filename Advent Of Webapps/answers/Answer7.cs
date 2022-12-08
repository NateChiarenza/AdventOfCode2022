using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.answers
{
    public interface IAdvent7Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class directory
    {
        public int size;
        public string name;
        public List<directory> dir;

        public directory()
        {
            size = size;
            name = name;
            dir = new List<directory>();
        }

    }
    public class answer7 : IAdvent7Service
    {

        public answer7()
        {

        }
        private int total;

        public int loop(string[] input)
        {
            var sum = 0;

            if (input[0].Contains("cd") && !input[0].Contains(".."))
            {
                input = input.Skip(1).ToArray();
                
            }
            else if (input[0].Contains("dir"))
            {
                input = input.Skip(1).ToArray();
                sum += loop(input);
            }
            else if (!input[0].Contains("..") && !input[0].Contains("ls") && Int32.Parse(input[0].Split(" ")[0]) > 0)
            {
                sum += Int32.Parse(input[0].Split(" ")[0]);
                if (input.Length > 1)
                {
                    input = input.Skip(1).ToArray();
                    sum += loop(input);
                }

            }
            
            if (input[0].Contains("ls"))
            {
                input = input.Skip(1).ToArray();
                sum += loop(input);
            }
            

            return sum;
        }

        //1002358
        //787432
        public async Task<string> part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var commands = Text.Split("\r\n");
                var system = new Dictionary<string, directory>();
                system.Add("/", new directory { name = "/" });
                var cdir = "";
                var index = 0;
                var cat = 0;
                var counter = 0;
                loop(commands);
                return total.ToString();
                foreach (var item in commands)
                {
                    var temp = item.Split(' ');
                    if (temp[0] == "$")
                    {
                        if (temp[1] != "ls")
                        {
                            if (temp[2] == "..")
                            {
                                cat--;
                            }
                            else if (temp[1] == "cd")
                            {
                                cat++;
                                cdir = temp[2];
                            }
                        }



                    }
                    else
                    {
                        if (temp[0] == "dir")
                        {
                            system[cdir].dir.Add(new directory { name = temp[1] });
                            if (!system.ContainsKey(temp[1]) && !system.ContainsKey(temp[1] + cat))
                            {
                                system.Add(temp[1], new directory { name = temp[1] });
                            }
                            else
                            {
                                system.Add(temp[1] + cat, new directory { name = temp[1] + cat });

                            }

                        }
                        else
                        {
                            system[cdir].size += Int32.Parse(temp[0]);
                        }

                    }
                    //4665991

                }
                foreach (var i in system.Reverse())
                {
                    foreach (var item in i.Value.dir)
                    {
                        i.Value.size += system[item.name].size;
                    }
                }
                foreach (var i in system)
                {
                    if (i.Value.size < 100000)
                    {
                        index += i.Value.size;
                    }
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
                return index.ToString();
            }
        }
    }
}
