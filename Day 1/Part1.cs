using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    internal class Part1
    {
        static List<string> input;

        static public int GetAnswer()
        {
            input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt")).ToList();
            List<string[]> splitLines = input.Select(line => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();
            List<int> list1 = splitLines.Select(line => Int32.Parse(line[0])).OrderBy(x => x).Cast<int>().ToList();
            List<int> list2 = splitLines.Select(line => Int32.Parse(line[1])).OrderBy(x => x).Cast<int>().ToList();
            List<int> differences = list1.Select((num, i) => Math.Abs(num - list2[i])).ToList();
            int sum = differences.Sum();
            return sum;
        }
    }
}