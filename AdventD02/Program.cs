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
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;

            foreach (var row in input)
            {
                if (row.direction == "forward")
                {
                    horizontalPosition += row.value;
                    depth += row.value * aim;
                }
                if (row.direction == "down") aim += row.value;
                if (row.direction == "up") aim -= row.value;
            }
            //PART 1
            Console.WriteLine("Part1: " + horizontalPosition * aim);

            //PART 2
            Console.WriteLine("Part2: " + horizontalPosition * depth);
        }
    }
}
