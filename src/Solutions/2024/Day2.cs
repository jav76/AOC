

namespace AOC.Solutions._2024
{
    internal class Day2 : SolutionBase, ISolution
    {
        List<List<int>> _reports = new();

        public override void Init(string inputText)
        {
            base.Init(inputText);
            SetReports();
        }

        public override string Part1Solution()
        {
            int validReports = 0;

            foreach (List<int> report in _reports)
            {
                if (IsSafeBySequence(report) && IsSafeByDifference(report))
                {
                    validReports++;
                }
            }

            return validReports.ToString();
        }

        public override string Part2Solution()
        {
            int validReports = 0;

            foreach (List<int> report in _reports)
            {
                if (IsSafeBySequence(report) && IsSafeByDifference(report))
                {
                    validReports++;
                    continue;
                }

                for (int i = 0; i < report.Count; i++)
                {
                    List<int> newReport = new(report);
                    newReport.RemoveAt(i);
                    if (IsSafeBySequence(newReport) && IsSafeByDifference(newReport))
                    {
                        validReports++;
                        break;
                    }
                }
            }

            return validReports.ToString();
        }

        private static bool IsSafeBySequence(IEnumerable<int> report)
        {
            return (report.SequenceEqual(report.OrderBy(x => x).ToList())
                    || report.SequenceEqual(report.OrderByDescending(x => x).ToList()));
        }

        private static bool IsSafeByDifference(IEnumerable<int> report)
        {
            bool valid = true;
            for (int i = 0; i < report.Count(); i++)
            {
                if (i > 0 && i < report.Count() - 1)
                {
                    int previousDifference = Math.Abs(report.ElementAt(i) - report.ElementAt(i - 1));
                    int nextDifference = Math.Abs(report.ElementAt(i + 1) - report.ElementAt(i));
                    if (previousDifference > 3 || previousDifference < 1
                        || nextDifference > 3 || nextDifference < 1)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            return valid;
        }

        private void SetReports()
        {
            List<List<int>> reports = new();
            foreach (string report in InputLines)
            {
                reports.Add(report.Split(" ").Select(x => int.Parse(x)).ToList());
            }
            _reports = reports;
        }
    }
}