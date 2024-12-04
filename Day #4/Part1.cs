using Day_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_4
{
    internal class Part1
    {
        static public int GetAnswer(string input)
        {
            List<List<char>> wordSearch = input.Split('\n').Select(x => x.ToList()).ToList();
            int wordSearchHeight = wordSearch.Count;
            int wordSearchWidth = wordSearch[0].Count - 1;
            List<char> search = new List<char>() { 'X', 'M', 'A', 'S' };
            int wordOccurences = 0;

            for (int x = 0; x < wordSearchWidth; x++)
            {
                for (int y = 0; y < wordSearchHeight; y++)
                {
                    List<int[]> possibleDirections = new List<int[]>() {
                        new int[] { 1, 1 },
                        new int[] { 1, -1 },
                        new int[] { -1, -1 },
                        new int[] { -1, 1 },
                        new int[] { 1, 0 },
                        new int[] { -1, 0 },
                        new int[] { 0, 1 },
                        new int[] { 0, -1 }
                    };
                    for (int i = 0; i < search.Count; i++)
                    {
                        char curr = search[i];
                        for (int j = 0; j < possibleDirections.Count; j++)
                        {
                            int[] direction = possibleDirections[j];
                            int[] scaledDirection = direction.Select(a => a * i).ToArray();
                            int offsetX = x + scaledDirection[0];
                            int offsetY = y + scaledDirection[1];
                            if (offsetX < 0 || wordSearchWidth <= offsetX || offsetY < 0 || wordSearchHeight <= offsetY)
                            {
                                possibleDirections.RemoveAt(j);
                                j--;
                                continue;
                            }
                            if (wordSearch[offsetY][offsetX] != curr)
                            {
                                possibleDirections.RemoveAt(j);
                                j--;
                                continue;
                            }
                        }
                    }
                    wordOccurences += possibleDirections.Count;
                }
            }

            return wordOccurences;
        }
    }
}