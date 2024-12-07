using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_5
{
    internal class Part2
    {
        static List<PageRule> pageRules;
        static List<PageSequence> pageSequences;

        static public int GetAnswer(List<string> lines)
        {
            int splitIndex = lines.FindIndex(line => line == "");
            pageRules = lines.GetRange(0, splitIndex).ConvertAll(line => new PageRule(line));
            pageSequences = lines.GetRange(splitIndex + 1, lines.Count - splitIndex - 1).ConvertAll(line => new PageSequence(line));

            List<PageSequence> invalidPageSequences = pageSequences.FindAll(x => !PageSequenceIsValid(x));
            List<PageSequence> validPageSequences = invalidPageSequences.Select(pageSequence => SortSequence(pageSequence)).ToList();
            int sumOfMiddles = validPageSequences.Aggregate(0, (int acc, PageSequence sequence) => { return acc + sequence.GetMiddle(); });
            return sumOfMiddles;
        }

        static PageSequence SortSequence(PageSequence sequence)
        {
            PageSequence sortedSequence = sequence;
            while (!PageSequenceIsValid(sortedSequence))
            {
                for (int i = 0; i < sequence.pages; i++)
                {
                    for (int j = sequence.pages - 1; j > i; j--)
                    {
                        if (!PagePairIsValid(sortedSequence[i], sortedSequence[j]))
                        {
                            int temp = sortedSequence[i];
                            sortedSequence[i] = sortedSequence[j];
                            sortedSequence[j] = temp;
                        }
                    }
                }
            }
            return sortedSequence;
        }

        static bool PageSequenceIsValid(PageSequence pageSequence)
        {
            if (pageSequence.pages < 1) return true;
            for (int i = 0; i < pageSequence.pages - 1; i++)
            {
                for (int j = i; j < pageSequence.pages; j++)
                {
                    if (!PagePairIsValid(pageSequence[i], pageSequence[j])) return false;
                }
            }
            return true;
        }

        static bool PagePairIsValid(int pageNumber1, int pageNumber2)
        {
            return pageRules.All(pageRule => pageRule.PagePairValid(pageNumber1, pageNumber2));
        }
    }
}