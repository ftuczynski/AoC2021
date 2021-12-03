using System;
using System.IO;
using System.Linq;

namespace AdventD03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ Advent Of Code Day 3 ------");
            var input = File.ReadAllLines("input.txt").Select(s => s.ToList()).ToList();
            string g = "", e = "";
            for(int i = 0; i < input[0].Count; i++)
            {
                var hasMoreOnes = input.Where(x => x[i] == '1').Count() > input.Count / 2;
                g += hasMoreOnes ? "1" : "0";
                e += hasMoreOnes ? "0" : "1";
            }
            //PART 1
            Console.WriteLine("Part1: " + Convert.ToInt16(g, 2) * Convert.ToInt16(e, 2));
        }
    }
}
