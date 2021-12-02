using System;
using System.IO;
using System.Linq;

namespace AdventD02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ Advent Of Code Day 2 ------");

            var input = File.ReadAllLines("input.txt").Select(x => new { direction = x.Split(' ')[0], value = int.Parse(x.Split(' ')[1]) }).ToList();
            int h = 0, d = 0, a = 0;

            foreach (var row in input)
            {
                switch (row.direction)
                {
                    case "forward":
                        h += row.value;
                        d += row.value * a;
                        break;
                    case "down":
                        a += row.value;
                        break;
                    case "up":
                        a -= row.value;
                        break;
                }
            }

            //PART 1
            Console.WriteLine("Part1: " + h * a);

            //PART 2
            Console.WriteLine("Part2: " + h * d);
        }
    }
}
