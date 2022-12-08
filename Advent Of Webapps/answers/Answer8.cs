using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_Of_Webapps.answers
{
    public interface IAdvent8Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class answer8 : IAdvent8Service
    {

        public answer8()
        {

        }



        public async Task<string> part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var total = 0;
                var forest = Text.Split("\r\n");
                var firstLine = forest[0].ToCharArray();
                var lastLine = forest[forest.Length - 1].ToCharArray();

                total += firstLine.Length;
                total += lastLine.Length;
                foreach (var line in forest)
                {
                    var trees = line.ToCharArray();
                    if (line == forest[0] || line == forest[forest.Length - 1])
                    {
                        continue;
                    }
                    var right = new Queue<int>();
                    foreach (var tree in trees)
                    {
                        right.Enqueue(Int32.Parse(tree.ToString()));
                    }
                    var left = new Queue<int>();


                    for (int i = 0; i < trees.Length; i++)
                    {
                        if (right.Count > 1)
                        {
                            right.Dequeue();
                        }
                        else
                        {
                            total++;
                            continue;
                        }

                        if (i == 0)
                        {
                            total++;
                            left.Enqueue(Int32.Parse(trees[i].ToString()));

                            continue;
                        }
                        if (Int32.Parse(trees[i].ToString()) > Int32.Parse(firstLine[i].ToString()))
                        {

                            var tallest = true;
                            var start = false;
                            foreach (var t in forest.Reverse())
                            {
                                if (line == t)
                                {
                                    start = true;
                                }
                                else if (start && Int32.Parse(trees[i].ToString()) > Int32.Parse(t.ToCharArray()[i].ToString()))
                                {
                                    continue;
                                }
                                else if (start)
                                {
                                    tallest = false;
                                    break;
                                }
                            }
                            if (tallest)
                            {
                                total++;
                                left.Enqueue(Int32.Parse(trees[i].ToString()));
                                continue;
                            }



                        }
                        if (Int32.Parse(trees[i].ToString()) > Int32.Parse(lastLine[i].ToString()))
                        {
                            var tallest = true;
                            var start = false;
                            foreach (var t in forest)
                            {
                                if (line == t)
                                {
                                    start = true;
                                }
                                else if (start && Int32.Parse(trees[i].ToString()) > Int32.Parse(t.ToCharArray()[i].ToString()))
                                {
                                    continue;
                                }
                                else if (start)
                                {
                                    tallest = false;
                                    break;
                                }
                            }
                            if (tallest)
                            {
                                total++;
                                left.Enqueue(Int32.Parse(trees[i].ToString()));
                                continue;
                            }

                        }
                        if (Int32.Parse(trees[i].ToString()) > right.Max())
                        {
                            total++;
                            left.Enqueue(Int32.Parse(trees[i].ToString()));
                            continue;
                        }
                        if (Int32.Parse(trees[i].ToString()) > left.Max())
                        {
                            total++;
                            left.Enqueue(Int32.Parse(trees[i].ToString()));
                            continue;
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
                var total = 0;
                var forest = Text.Split("\r\n");
                var firstLine = forest[0].ToCharArray();
                var lastLine = forest[forest.Length - 1].ToCharArray();
                var up = 0;
                var down = 0;
                var Left = 0;
                var Right = 0;
                var best = 0;
                foreach (var line in forest)
                {
                    var trees = line.ToCharArray();

                    for (int i = 0; i < trees.Length; i++)
                    {
                        var start = false;
                        foreach (var t in forest.Reverse())
                        {
                            if (line == t)
                            {
                                start = true;
                            }
                            else if (start && Int32.Parse(trees[i].ToString()) > Int32.Parse(t.ToCharArray()[i].ToString()))
                            {
                                up++;
                            }
                            else if (start)
                            {
                                up++;
                                break;
                            }
                        }

                        start = false;
                        foreach (var t in forest)
                        {
                            if (line == t)
                            {
                                start = true;
                            }
                            else if (start && Int32.Parse(trees[i].ToString()) > Int32.Parse(t.ToCharArray()[i].ToString()))
                            {
                                down++;
                            }
                            else if (start)
                            {
                                down++;
                                break;
                            }
                        }
                        for (int j = i + 1; j < trees.Length; j++)
                        {
                            if (Int32.Parse(trees[i].ToString()) > Int32.Parse(trees[j].ToString()))
                            {
                                Right++;
                            }
                            else if (Int32.Parse(trees[i].ToString()) == Int32.Parse(trees[j].ToString()))
                            {
                                Right++;
                                break;
                            }
                            else
                            {
                                Right++;
                                break;
                            }
                        }
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (Int32.Parse(trees[i].ToString()) > Int32.Parse(trees[j].ToString()))
                            {
                                Left++;
                            }
                            else if (Int32.Parse(trees[i].ToString()) == Int32.Parse(trees[j].ToString()))
                            {
                                Left++;
                                break;
                            }
                            else
                            {
                                Left++;
                                break;
                            }
                        }
                        var temp = up * down * Left * Right;
                        if (best < temp)
                        {
                            best = temp;
                        }
                        up = 0;
                        down = 0;
                        Left = 0;
                        Right = 0;
                    }

                }

                total = best;
                return total.ToString();
            }
        }
    }
}
