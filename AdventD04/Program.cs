using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventD04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ Advent Of Code Day 4 ------");
            var numbers = File.ReadAllLines("input.txt")[0]
                .Split(',')
                .Select(x => Convert.ToInt32(x))
                .ToList();

            var boards = File.ReadAllText("input.txt")
                .Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)
                .Skip(1)
                .Select(r => r.Split(new string[] { "\r\n" }, StringSplitOptions.None)
                    .Select(c => c.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => Convert.ToInt32(x))
                        .ToList())
                    .ToList())
                .ToList();

            bool winner = false;
            var winnerResult = 0;
            var loserResult = 0;
            var numbersCalled = new List<int>();
            foreach(var num in numbers)
            {
                var winningBoards = new List<List<List<int>>>();
                numbersCalled.Add(num);
                foreach(var board in boards)
                {
                    for (int i = 0; i < board.Count; i++)
                    {
                        var rowWinning = board[i].Intersect(numbersCalled).ToList().Count() == board.Count;
                        var colWinning = board.Select(c => c[i]).ToList().Intersect(numbersCalled).ToList().Count() == board.Count;
                        if (rowWinning || colWinning)
                        {
                            winningBoards.Add(board);
                            if (!winner)
                            {
                                winnerResult = board.Select(c => c.Where(r => !numbersCalled.Contains(r)).Sum()).Sum() * num;
                                winner = true;
                                break;
                            }
                            else
                            {
                                loserResult = board.Select(c => c.Where(r => !numbersCalled.Contains(r)).Sum()).Sum() * num;
                                break;
                            }
                        }
                    }
                }
                winningBoards.ForEach(x => boards.Remove(x));
                winningBoards.Clear();
            }

            //PART 1
            Console.WriteLine("Part1: " + winnerResult);

            //PART 1
            Console.WriteLine("Part2: " + loserResult);
        }
    }
}
