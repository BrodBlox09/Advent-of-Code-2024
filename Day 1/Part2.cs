using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    internal class Part2
    {
        static List<string> input;

        static public int GetAnswer()
        {
            input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt")).ToList();
            List<string[]> splitLines = input.Select(line => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();
            List<int> list1 = splitLines.Select(line => Int32.Parse(line[0])).OrderBy(x => x).Cast<int>().ToList();
            List<int> list2 = splitLines.Select(line => Int32.Parse(line[1])).OrderBy(x => x).Cast<int>().ToList();
            int similarityScore = 0;
            int listLength = list1.Count;
            for (int i = 0; i < listLength; i++)
            {
                int num = list1[i];
                int multiples = list2.FindAll(x => x == num).Count;
                similarityScore += num * multiples;
            }
            return similarityScore;
        }
    }
}
