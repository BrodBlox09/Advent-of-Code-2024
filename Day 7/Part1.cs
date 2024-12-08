using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_7
{
    internal class Part1
    {
        static List<char> validOperands = new List<char>() { '+', '*' };
        static int numValidOperands = validOperands.Count;

        static public long GetAnswer(List<Equation> input)
        {
            List<Equation> possibleValidEquations = new List<Equation>();
            input.ForEach(eq =>
            {
                long target = eq.testValue;
                List<int> opIndices = MakeStartingOpIndicesList(eq);
                int numOps = opIndices.Count;
                while (opIndices.Count == numOps)
                {
                    List<char> ops = opIndices.Select(opIndex => validOperands[opIndex]).ToList();
                    if (ExpressionEvalsTo(eq.numbers, ops, target))
                    {
                        possibleValidEquations.Add(eq);
                        break;
                    }

                    opIndices = IncrementOpIndices(opIndices);
                }
            });

            long totalCalibrationResult = possibleValidEquations.Aggregate(0, (long acc, Equation eq) => acc + eq.testValue);
            return totalCalibrationResult;
        }

        static List<int> IncrementOpIndices(List<int> ints)
        {
            int lastIndex = ints.Count - 1;
            if (lastIndex == -1) return new List<int>() { 1 };
            ints[lastIndex]++;
            if (ints[lastIndex] >= numValidOperands)
            {
                List<int> littleInts = IncrementOpIndices(ints.GetRange(0, lastIndex));
                littleInts.Add(0);
                ints = littleInts;
            }
            return ints;
        }

        static List<int> MakeStartingOpIndicesList(Equation eq)
        {
            List<int> result = new List<int>();
            int opCount = eq.numbers.Count - 1;
            for (int i = 0; i < opCount; i++)
            {
                result.Add(0);
            }
            return result;
        }

        static bool ExpressionEvalsTo(List<long> ints, List<char> operands, long target)
        {
            if (ints.Count != operands.Count + 1) throw new ArgumentException("Operands are not valid for int list.");
            long answer = ints[0];
            for (int i = 0; i + 1 < ints.Count; i++)
            {
                switch (operands[i])
                {
                    case '+':
                        {
                            answer += ints[i + 1];
                            break;
                        }
                    case '*':
                        {
                            answer *= ints[i + 1];
                            break;
                        }
                    default: throw new ArgumentException($"Operand {i} is not valid.");
                }
                if (answer > target) return false;
            }
            return answer == target;
        }
    }
}