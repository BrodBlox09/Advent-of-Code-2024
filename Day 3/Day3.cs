using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    internal class Day3
    {
        static public string input;

        static void Main(string[] args)
        {
            input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt"));

            int part1Answer = Part1.GetAnswer();
            int part2Answer = Part2.GetAnswer();

            Console.WriteLine($"Part 1 Answer: {part1Answer}");
            Console.WriteLine($"Part 2 Answer: {part2Answer}");
        }
    }
}
