using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_7
{
    internal class Day7
    {
        static List<Equation> input;

        static void Main(string[] args)
        {
            input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt")).Select(l => new Equation(l)).ToList();

            //long part1Answer = Part1.GetAnswer(input);
            //Console.WriteLine($"Part 1 Answer: {part1Answer}");

            long part2Answer = Part2.GetAnswer(input);
            Console.WriteLine($"Part 2 Answer: {part2Answer}");
        }
    }

    struct Equation
    {
        public long testValue;
        public List<long> numbers;

        public Equation(string equationLine)
        {
            List<long> numbers = Regex.Matches(equationLine, @"\d+").Cast<Match>().Select(x => long.Parse(x.Value)).ToList();
            this.testValue = numbers[0];
            numbers.RemoveAt(0);
            this.numbers = numbers;
        }
    }
}
