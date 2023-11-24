
namespace AOC.Solutions
{
    /// <summary>
    /// Generic solution template that each of the day's solutions can inherit from. 
    /// </summary>
    internal abstract class SolutionBase : ISolution
    {
        public string InputText { get; set; } = string.Empty;
        public List<string> InputLines { get; set; } = new List<string>();

        public SolutionBase()
        {

        }

        public void Init(string inputText)
        {
            InputText = inputText;
            InputLines = inputText.Split('\n').ToList();
        }

        public virtual string Part1Solution()
        {
            /// Do the stuff
            
            return string.Empty; // Return the solution
        }

        public virtual string Part2Solution()
        {
            /// Do the stuff

            return string.Empty; // Return the solution
        }

        public (string? part1, string? part2) GenerateSolutions()
        {
            return GenerateSolutionsInternal();
        }

        private (string? part1, string? part2) GenerateSolutionsInternal()
        {
            return
            (
                GenerateSolutionPart(1),
                GenerateSolutionPart(2)
            );
        }

        private string? GenerateSolutionPart(short part)
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

            return solutionText;
        }
    }
}
