using Day_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_3
{
    internal class Part2
    {
        static public int GetAnswer()
        {
            string input = Day3.input;
            MatchCollection matches = Regex.Matches(input, @"(mul|do|don't)\((?:(\d+?),(\d+?))?\)");
            int tot = 0;
            bool multiplicationEnabled = true;

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                string func = groups[1].Value;
                switch (func)
                {
                    case "mul":
                        if (!multiplicationEnabled) continue;
                        int num1 = Int32.Parse(groups[2].Value);
                        int num2 = Int32.Parse(groups[3].Value);
                        tot += num1 * num2;
                        break;
                    case "do":
                        multiplicationEnabled = true;
                        break;
                    case "don't":
                        multiplicationEnabled = false;
                        break;
                }
            }

            return tot;
        }
    }
}
