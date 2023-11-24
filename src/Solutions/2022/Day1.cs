

namespace AOC.Solutions._2022
{
    internal class Day1 : SolutionBase, ISolution
    {

        private List<int> calorieSums= new List<int>();

        private List<int> GetCalorieSums(List<string> inputLines)
        {
            List<int> calorieSums = new List<int>();
            int currentSum = 0;

            foreach (string line in inputLines)
            {
                if (line.Length == 0)
                {
                    calorieSums.Add(currentSum);
                    currentSum = 0;
                }

                int currentCalories = 0;
                if (int.TryParse(line, out currentCalories))
                {
                    currentSum += currentCalories;
                }
            }

            return calorieSums;
        }

        public override string Part1Solution()
        {
            return GetCalorieSums(InputLines)
                .OrderBy(x => x)
                .Reverse()
                .First()
                .ToString();
        }

        public override string Part2Solution()
        {
            List<int> top3 = GetCalorieSums(InputLines)
                .OrderBy(x => x)
                .Reverse()
                .Take(3)
                .ToList();

            return top3.Sum().ToString();
        }
    }
}
