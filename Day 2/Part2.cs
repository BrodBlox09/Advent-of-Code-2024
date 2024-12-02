using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    internal class Part2
    {
        static public int GetAnswer()
        {

            List<List<int>> lines = Day2.input.Select(x =>
            {
                string[] numStrings = x.Split(' ');
                return numStrings.Select(y => Int32.Parse(y)).ToList();
            }).ToList();
            int numLinesSafe = 0;
            lines.ForEach(line =>
            {
                for (int i = -1; i < line.Count; i++)
                {
                    List<int> modifiedLine = line.Where((_, index) => index != i).ToList();
                    if (LineIsSafe(modifiedLine))
                    {
                        numLinesSafe++;
                        return;
                    }
                }
                return;
            });

            return numLinesSafe;
        }
        
        static bool LineIsSafe(List<int> line)
        {
            List<int> differences = GetDifferencesFrom(line);
            int sig = Math.Sign(differences[0]);
            if (differences.Any(x => Math.Sign(x) != sig)) return false;
            if (!differences.All(x => 1 <= Math.Abs(x) && Math.Abs(x) <= 3)) return false;
            return true;
        }

        static List<int> GetDifferencesFrom(List<int> line)
        {
            List<int> differences = new List<int>();

            for (int i = 0; i < line.Count - 1; i++)
            {
                differences.Add(line[i] - line[i + 1]);
            }

            return differences;
        }
    }
}
