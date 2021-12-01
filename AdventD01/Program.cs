using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventD01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ Advent Of Code Day 1 ------");
            var input = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();

            //PART 1
            Console.WriteLine("Part1: " + Solve(input, 1));

            //PART 2
            Console.WriteLine("Part2: " + Solve(input, 3));
        }

        static int Solve(List<int> input, int windowSize)
        {
            var result = 0;
            for (int i = 0; i < input.Count - windowSize; i++)
            {
                var sum1 = input.Skip(i).Take(windowSize).Sum();
                var sum2 = input.Skip(i+1).Take(windowSize).Sum();
                if (sum1 < sum2) result++;
            }
            return result;
        }
    }
}
