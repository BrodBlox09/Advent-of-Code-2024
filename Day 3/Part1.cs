using Day_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_3
{
    internal class Part1
    {
        static public int GetAnswer()
        {
            string input = Day3.input;
            MatchCollection matches = Regex.Matches(input, @"mul\((\d+?),(\d+?)\)");
            int tot = 0;
            
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                int num1 = Int32.Parse(groups[1].Value);
                int num2 = Int32.Parse(groups[2].Value);
                tot += num1 * num2;
            }

            return tot;
        }
    }
}
