
namespace AOC.Solutions
{
    /// <summary>
    /// Generic solution template that each of the day's solutions can inherit from. 
    /// </summary>
    internal abstract class SolutionBase : ISolution
    {
        private string _inputText { get; set; } = string.Empty;

        public SolutionBase()
        {

        }

        public void Init(string inputText)
        {
            _inputText = inputText;
        }

        public string Part1Solution()
        {
            /// Do the stuff
            
            return string.Empty; // Return the solution
        }

        public string Part2Solution()
        {
            /// Do the stuff

            return string.Empty; // Return the solution
        }

        public (string? part1, string? part2) GenerateSolutions(string outputPath)
        {
            GenerateSolutionsInternal(outputPath);

            return (null, null); // todo return solutions here
        }

        private void GenerateSolutionsInternal(string outputPath)
        {
            GenerateSolutionPart(outputPath, 1);
            GenerateSolutionPart(outputPath, 2);
        }

        private void GenerateSolutionPart(string outputPath, short part)
        {
            string solutionText = string.Empty;
            switch (part)
            {
                case 1:
                    solutionText = Part1Solution();
                    break;
                case 2:
                    solutionText = Part2Solution();
                    break;

                default:
                    throw new InvalidOperationException("Invalid solution part.");
            } 

            using(StreamWriter writer = new StreamWriter(solutionText))
            {
                writer.Write(solutionText);
            }

        }
    }
}
