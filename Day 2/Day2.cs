using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    internal class Day2
    {
        static public List<string> input;

        static void Main(string[] args)
        {
            input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt")).ToList();

            int part1Answer = Part1.GetAnswer();
            int part2Answer = Part2.GetAnswer();

            Console.WriteLine($"Part 1 Answer: {part1Answer}");
            Console.WriteLine($"Part 2 Answer: {part2Answer}");
        }
    }
}
