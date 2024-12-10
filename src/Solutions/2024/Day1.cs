

namespace AOC.Solutions._2024
{
    internal class Day1 : SolutionBase, ISolution
    {
        List<int> _numbers1 = new();
        List<int> _numbers2 = new();

        public override void Init(string inputText)
        {
            base.Init(inputText);
            SetNumberPairs();
        }

        public override string Part1Solution()
        {
            int differenceSum = 0;
            IReadOnlyList<int> sortedNumbers1 = _numbers1.OrderBy(x => x).ToList();
            IReadOnlyList<int> sortedNumbers2 = _numbers2.OrderBy(x => x).ToList();

            foreach ((int, int) pair in sortedNumbers1.Zip(sortedNumbers2))
            {
                differenceSum += Math.Abs(pair.Item2 - pair.Item1);
            }

            return differenceSum.ToString();
        }

        public override string Part2Solution()
        {
            int similarityScore = 0;

            foreach (int number1 in _numbers1)
            {
                similarityScore += number1 * _numbers2.Count(x => x == number1);
            }

            return similarityScore.ToString(); 
        }

        private void SetNumberPairs()
        {
            List<int> numbers1 = new();
            List<int> numbers2 = new();

            foreach ((int, int) pair in InputLines
                                            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                                            .Select(x => (int.Parse(x[0]), int.Parse(x[1]))))
            {
                numbers1.Add(pair.Item1);
                numbers2.Add(pair.Item2);
            }

            _numbers1 = numbers1;
            _numbers2 = numbers2;
        }
    }
}