using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_5
{
    internal class Day5
    {
        static public List<string> input;

        static void Main(string[] args)
        {
            input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt")).ToList();

            int part1Answer = Part1.GetAnswer(input);
            int part2Answer = Part2.GetAnswer(input);

            Console.WriteLine($"Part 1 Answer: {part1Answer}");
            Console.WriteLine($"Part 2 Answer: {part2Answer}");
        }
    }

    struct PageRule
    {
        private int firstPageNumber;
        private int lastPageNumber;

        public PageRule(string pageRuleLine)
        {
            MatchCollection numbers = Regex.Matches(pageRuleLine, @"\d+");
            this.firstPageNumber = Int32.Parse(numbers[0].Value);
            this.lastPageNumber = Int32.Parse(numbers[1].Value);
        }

        public bool PagePairValid(int pageNumber1, int pageNumber2)
        {
            if (pageNumber2 == firstPageNumber && pageNumber1 == lastPageNumber) return false;
            return true;
        }
    }

    struct PageSequence : IEnumerable<int>
    {
        private List<int> sequence;

        public PageSequence(List<int> pages) { this.sequence = pages; }
        public PageSequence(string pageSequenceLine)
        {
            this.sequence = new List<int>();
            foreach (Match match in Regex.Matches(pageSequenceLine, @"\d+"))
            {
                sequence.Add(Int32.Parse(match.Value));
            }
        }

        public int GetMiddle()
        {
            return this.sequence[(int)Math.Floor(this.sequence.Count / 2f)];
        }

        public override string ToString()
        {
            return String.Join(", ", this.sequence);
        }

        public IEnumerator<int> GetEnumerator() { return sequence.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public int this[int i] { get { return sequence[i]; } set { sequence[i] = value; } }
        public int pages { get { return sequence.Count; } }
    }
}
