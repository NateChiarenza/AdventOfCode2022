using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.answers
{
    public interface IAdvent5Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class answer5 : IAdvent5Service
    {

        public answer5()
        {

        }



        public async Task<string> part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var rounds = Text.Split("\r\n");
                var elements = new List<char[]>();
                var instructions = new List<char[]>();

                var lists = new List<LinkedList<char>>(new LinkedList<char>[9]);
                var tops = "";
                for (int i = 0; i < 8; i++)
                {
                    elements.Add(rounds[i].ToCharArray());
                }
                for (int i = 10; i < rounds.Length; i++)
                {
                    instructions.Add(rounds[i].ToCharArray());
                }
                for (var elm = 0; elm <= elements.Count; elm++)
                {
                    var link = new LinkedList<char>();
                    for (int i = 0; i <= elements.Count - 1; i++)
                    {
                        if (elements[i][(elm * 4) + 1] != ' ')
                        {
                            link.AddFirst(elements[i][(elm * 4) + 1]);
                        }

                    }

                    lists[elm] = link;
                }


                foreach (var instruction in instructions)
                {

                    var b = instruction[5] + "";
                    if (instruction[6] != 32)
                    {
                        b += instruction[6];
                    }
                    for (int i = 0; i <= Int32.Parse(b) - 1; i++)
                    {

                        if (instruction[13] != ' ')
                        {
                            lists[(instruction[18] - 49)].AddLast(lists[(instruction[13] - 49)].Last.Value);
                            lists[instruction[13] - 49].RemoveLast();
                        }
                        else
                        {

                            lists[(instruction[17] - 49)].AddLast(lists[(instruction[12] - 49)].Last.Value);
                            lists[instruction[12] - 49].RemoveLast();

                        }

                    }
                }
                foreach (var item in lists)
                {
                    if (item.Count > 0)
                    {
                        tops += item.Last.Value;
                    }
                }
                return tops.ToString();
            }
        }

        public async Task<string> part2(IFormFile input)
        {
            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var rounds = Text.Split("\r\n");
                var elements = new List<char[]>();
                var instructions = new List<char[]>();

                var lists = new List<List<char>>(new List<char>[9]);
                var tops = "";
                for (int i = 0; i < 8; i++)
                {
                    elements.Add(rounds[i].ToCharArray());
                }
                for (int i = 10; i < rounds.Length; i++)
                {
                    instructions.Add(rounds[i].ToCharArray());
                }
                for (var elm = 0; elm <= elements.Count; elm++)
                {
                    var link = new List<char>();
                    for (int i = 0; i <= elements.Count - 1; i++)
                    {
                        if (elements[i][(elm * 4) + 1] != ' ')
                        {
                            link.Add(elements[i][(elm * 4) + 1]);
                        }

                    }

                    lists[elm] = link;
                }

                foreach (var instruction in instructions)
                {
                    var temp = new List<char>();
                    var b = instruction[5] + "";
                    if (instruction[6] != 32)
                    {
                        b += instruction[6];
                    }
                    for (int i = 0; i <= Int32.Parse(b) - 1; i++)
                    {

                        if (instruction[13] != ' ')
                        {
                            temp.Add(lists[instruction[13] - 49][0]);
                            lists[instruction[13] - 49].RemoveAt(0);
                        }
                        else
                        {
                            temp.Add(lists[instruction[12] - 49][0]);
                            lists[instruction[12] - 49].RemoveAt(0);
                        }






                    }
                    

                        if (instruction[13] != ' ')
                        {
                            lists[instruction[18] - 49].InsertRange(0, temp);
                        }

                        else
                        {
                            lists[instruction[17] - 49].InsertRange(0, temp);
                        }


                }
                foreach (var item in lists)
                {
                    if (item.Count > 0)
                    {
                        tops += item[0];
                    }
                }
                return tops.ToString();
            }
        }
    }
}
