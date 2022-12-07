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
                var one = new LinkedList<char>();
                var two = new LinkedList<char>();
                var three = new LinkedList<char>();
                var four = new LinkedList<char>();
                var five = new LinkedList<char>();
                var six = new LinkedList<char>();
                var seven = new LinkedList<char>();
                var eight = new LinkedList<char>();
                var nine = new LinkedList<char>();
                var lists = new List<LinkedList<char>>();
                var tops = "";
                for (int i = 0; i < 8; i++)
                {
                    elements.Add(rounds[i].ToCharArray());
                }
                for (int i = 10; i < rounds.Length; i++)
                {
                    instructions.Add(rounds[i].ToCharArray());
                }
                for (var elm = 0; elm <= elements.Count - 1; elm++)
                {
                    if (!(elements[elm][1] == ' '))
                    {
                        one.AddFirst(elements[elm][1]);
                    }
                    if (!(elements[elm][5] == ' '))
                    {
                        two.AddFirst(elements[elm][5]);
                    }
                    if (!(elements[elm][9] == ' '))
                    {
                        three.AddFirst(elements[elm][9]);
                    }
                    if (!(elements[elm][13] == ' '))
                    {
                        four.AddFirst(elements[elm][13]);
                    }
                    if (!(elements[elm][17] == ' '))
                    {
                        five.AddFirst(elements[elm][17]);
                    }
                    if (!(elements[elm][21] == ' '))
                    {
                        six.AddFirst(elements[elm][21]);
                    }
                    if (!(elements[elm][25] == ' '))
                    {
                        seven.AddFirst(elements[elm][25]);
                    }
                    if (!(elements[elm][29] == ' '))
                    {
                        eight.AddFirst(elements[elm][29]);
                    }
                    if (!(elements[elm][33] == ' '))
                    {
                        nine.AddFirst(elements[elm][33]);
                    }

                }
                lists.Add(one);
                lists.Add(two);
                lists.Add(three);
                lists.Add(four);
                lists.Add(five);
                lists.Add(six);
                lists.Add(seven);
                lists.Add(eight);
                lists.Add(nine);

                foreach (var instruction in instructions)
                {

                    var b = instruction[5] + "";
                    if (instruction[6] != 32)
                    {
                        b += instruction[6];
                    }
                    for (int i = 0; i <= Int32.Parse(b) - 1; i++)
                    {
                        try
                        {
                            if (lists[(instruction[12] - 49)].Count != 0)
                            {
                                lists[(instruction[17] - 49)].AddLast(lists[(instruction[12] - 49)].Last.Value);
                                lists[instruction[12] - 49].RemoveLast();
                            }


                        }
                        catch (Exception)
                        {
                            try
                            {
                                if (lists[(instruction[13] - 49)].Count != 0)
                                {
                                    lists[(instruction[18] - 49)].AddLast(lists[(instruction[13] - 49)].Last.Value);
                                    lists[instruction[13] - 49].RemoveLast();
                                }
                            }
                            catch (Exception e)
                            {

                                break;
                            }


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
                var one = new List<char>();
                var two = new List<char>();
                var three = new List<char>();
                var four = new List<char>();
                var five = new List<char>();
                var six = new List<char>();
                var seven = new List<char>();
                var eight = new List<char>();
                var nine = new List<char>();
                var lists = new List<List<char>>();
                var tops = "";
                for (int i = 0; i < 8; i++)
                {
                    elements.Add(rounds[i].ToCharArray());
                }
                for (int i = 10; i < rounds.Length; i++)
                {
                    instructions.Add(rounds[i].ToCharArray());
                }
                for (var elm = 0; elm <= elements.Count - 1; elm++)
                {
                    if (!(elements[elm][1] == ' '))
                    {
                        one.Add(elements[elm][1]);
                    }
                    if (!(elements[elm][5] == ' '))
                    {
                        two.Add(elements[elm][5]);
                    }
                    if (!(elements[elm][9] == ' '))
                    {
                        three.Add(elements[elm][9]);
                    }
                    if (!(elements[elm][13] == ' '))
                    {
                        four.Add(elements[elm][13]);
                    }
                    if (!(elements[elm][17] == ' '))
                    {
                        five.Add(elements[elm][17]);
                    }
                    if (!(elements[elm][21] == ' '))
                    {
                        six.Add(elements[elm][21]);
                    }
                    if (!(elements[elm][25] == ' '))
                    {
                        seven.Add(elements[elm][25]);
                    }
                    if (!(elements[elm][29] == ' '))
                    {
                        eight.Add(elements[elm][29]);
                    }
                    if (!(elements[elm][33] == ' '))
                    {
                        nine.Add(elements[elm][33]);
                    }

                }
                lists.Add(one);
                lists.Add(two);
                lists.Add(three);
                lists.Add(four);
                lists.Add(five);
                lists.Add(six);
                lists.Add(seven);
                lists.Add(eight);
                lists.Add(nine);

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
                        try
                        {
                            if (lists[(instruction[12] - 49)].Count != 0)
                            {
                                temp.Add(lists[instruction[12] - 49][0]);
                                lists[instruction[12] - 49].RemoveAt(0);
                            }


                        }
                        catch (Exception)
                        {
                            try
                            {
                                if (lists[(instruction[13] - 49)].Count != 0)
                                {
                                    temp.Add(lists[instruction[13] - 49][0]);
                                    lists[instruction[13] - 49].RemoveAt(0);
                                }
                            }
                            catch (Exception e)
                            {

                                break;
                            }


                        }

                    }
                    try
                    {
                        lists[instruction[17] - 49].InsertRange(0, temp);
                    }
                    catch (Exception)
                    {

                        lists[instruction[18] - 49].InsertRange(0, temp); 
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
