
namespace AOC.Solutions
{
    /// <summary>
    /// Generic solution template that each of the day's solutions can inherit from. 
    /// </summary>
    internal abstract class SolutionBase : ISolution
    {
        public string InputText { get; set; } = string.Empty;
        public List<string> InputLines { get; set; } = new List<string>();

        protected SolutionBase() { }

        public virtual void Init(string inputText)
        {
            InputText = inputText;
            InputLines = inputText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// Implement the solution for part 1 of the day's puzzle.
        /// </summary>
        /// <returns>The solution should be returned as a string.</returns>
        public abstract string? Part1Solution();

        /// <summary>
        /// Implement the solution for part 2 of the day's puzzle.
        /// </summary>
        /// <returns>The solution should be returned as a string.</returns>
        public abstract string? Part2Solution();

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
            string? solutionText = part switch
            {
                1 => Part1Solution(),
                2 => Part2Solution(),
                _ => throw new InvalidOperationException("Invalid solution part."),
            };
            return solutionText;
        }
    }
}
