

namespace AOC.Solutions._2023
{
    internal class Day1 : SolutionBase, ISolution
    {
        public override string Part1Solution()
        {
            int calibrationSums = 0;
            char? firstDigit = null;
            char? lastDigit = null;

            foreach (string line in InputLines)
            {
                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        if (!firstDigit.HasValue)
                        {
                            firstDigit = c;
                        }
                        lastDigit = c;
                    }
                }

                int lineCombination;
                if (int.TryParse(string.Concat(firstDigit, lastDigit), out lineCombination))
                {
                    calibrationSums += lineCombination;
                }

                firstDigit = null;
                lastDigit = null;
            }

            return calibrationSums.ToString();
        }

        public override string Part2Solution()
        {
            return string.Empty;
        }
    }
}