using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventD03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ Advent Of Code Day 3 ------");
            var input = File.ReadAllLines("input.txt").Select(s => s.Select(b => b == '1').ToList()).ToList();
            List<bool> gamma = new List<bool>(), epsilon = new List<bool>();
            for (int i = 0; i < input[0].Count; i++)
            {
                var bit = MostCommonBit(input, i);
                gamma.Add(bit);
                epsilon.Add(!bit);
            }
            //PART 1
            Console.WriteLine("Part1: " + BoolToInt(gamma) * BoolToInt(epsilon));

            //PART 2
            var o2 = GetDiagnostics(input, 0, true)[0];
            var co2 = GetDiagnostics(input, 0, false)[0];
            Console.WriteLine("Part2: " + BoolToInt(o2) * BoolToInt(co2));
        }

        static List<List<bool>> GetDiagnostics(List<List<bool>> diagnostics, int index, bool mostCommon)
        {
            var bit = MostCommonBit(diagnostics, index);
            diagnostics = diagnostics.Where(d => d[index] == (mostCommon ? bit : !bit)).ToList();

            return diagnostics.Count > 1 ? GetDiagnostics(diagnostics, index + 1, mostCommon) : diagnostics;
        }

        static bool MostCommonBit(List<List<bool>> input, int index)
        {
            return input.Where(x => x[index]).Count() >= (input.Count + 1) / 2;
        }

        static double BoolToInt(List<bool> list)
        {
            return list.Reverse<bool>().Select((b, i) => b ? Math.Pow(2, i) : 0).Sum();
        }
    }
}
