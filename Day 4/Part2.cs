using Day_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_4
{
    internal class Part2
    {
        static List<List<char>> wordSearch;
        static int wordSearchHeight;
        static int wordSearchWidth;

        static public int GetAnswer(string input)
        {
            wordSearch = input.Split('\n').Select(x => x.ToList()).ToList();
            wordSearchHeight = wordSearch.Count;
            wordSearchWidth = wordSearch[0].Count - 1;
            int patternOccurences = 0;

            for (int x = 0; x < wordSearchWidth; x++)
            {
                for (int y = 0; y < wordSearchHeight; y++)
                {
                    if (PositionMatchesPattern(x, y)) patternOccurences++;
                }
            }

            return patternOccurences;
        }

        static bool PositionMatchesPattern(int x, int y)
        {
            if (!PositionIsInRange(x, y)) return false;
            if (wordSearch[y][x] != 'A') return false;
            if (!(wordSearch[y - 1][x - 1] == 'M' && wordSearch[y + 1][x + 1] == 'S') &&
                !(wordSearch[y - 1][x - 1] == 'S' && wordSearch[y + 1][x + 1] == 'M')) return false;
            if (!(wordSearch[y + 1][x - 1] == 'M' && wordSearch[y - 1][x + 1] == 'S') &&
                !(wordSearch[y + 1][x - 1] == 'S' && wordSearch[y - 1][x + 1] == 'M')) return false;
            return true;
        }

        static bool PositionIsInRange(int x, int y)
        {
            return !(x - 1 < 0 || wordSearchWidth <= x + 1 || y - 1 < 0 || wordSearchHeight <= y + 1);
        }
    }
}