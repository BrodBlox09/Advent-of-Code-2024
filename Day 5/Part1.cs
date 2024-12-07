using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_5
{
    internal class Part1
    {
        static List<PageRule> pageRules;
        static List<PageSequence> pageSequences;

        static public int GetAnswer(List<string> lines)
        {
            int splitIndex = lines.FindIndex(line => line == "");
            pageRules = lines.GetRange(0, splitIndex).ConvertAll(line => new PageRule(line));
            pageSequences = lines.GetRange(splitIndex + 1, lines.Count - splitIndex - 1).ConvertAll(line => new PageSequence(line));

            List<PageSequence> validPageSequences = pageSequences.FindAll(PageSequenceIsValid);
            int sumOfMiddles = validPageSequences.Aggregate(0, (int acc, PageSequence sequence) => { return acc + sequence.GetMiddle(); });
            return sumOfMiddles;
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