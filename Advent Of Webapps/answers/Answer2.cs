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
    public interface IAdvent2Service
    {
        Task<string> part1(IFormFile input);
        Task<string> part2(IFormFile input);
    }
    public class answer2 : IAdvent2Service
    {

        public answer2()
        {

        }



        public async Task<string> part1(IFormFile input)
        {

            using (var reader = new StreamReader(input.OpenReadStream()))
            {
                var Text = await reader.ReadToEndAsync();
                var rounds = Text.Split("\r\n");
                var total = 0;
                foreach (var round in rounds)
                {
                    var op = 0;
                    var me = 0;
                    var apple = round.Split(" ");
                    switch (apple[0])
                    {

                        case "A":
                            op = 1;
                            break;
                        case "B":
                            op = 2;
                            break;
                        case "C":
                            op = 3;

                            break;
                        default:
                            break;
                    }
                    switch (apple[1])
                    {
                        case "X":
                            me = 1;
                            break;
                        case "Y":
                            me = 2;
                            break;
                        case "Z":
                            me = 3;
                            break;
                        default:
                            break;
                    }
                    if (me + 1 == op || me - 2 == op)
                    {
                        total += me;
                    }
                    else if (op == me)
                    {
                        total += me + 3;
                    }
                    else
                    {
                        total += me + 6;
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
                foreach (var round in rounds)
                {
                    var op = 0;
                    var me = 0;
                    var apple = round.Split(" ");
                    switch (apple[0])
                    {

                        case "A":
                            op = 1;
                            break;
                        case "B":
                            op = 2;
                            break;
                        case "C":
                            op = 3;

                            break;
                        default:
                            break;
                    }
                    switch (apple[1])
                    {
                        case "X":
                            me = (op + 2);
                            if(me > 3)
                            {
                                me =me - 3;
                            }
                            total += me;
                            break;
                        case "Y":
                            total += op + 3;
                            break;
                        case "Z":
                            me = (op + 1);
                            if (me > 3)
                            {
                                me = me - 3;
                            }
                            total += me + 6;
                            break;
                        default:
                            break;
                    }

                }
                return total.ToString();
            }
        }
    }
}
