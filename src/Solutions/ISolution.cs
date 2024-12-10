namespace AOC.Solutions
{
    internal interface ISolution
    {
        public void Init(string inputText);
        public string? Part1Solution();
        public string? Part2Solution();
        public (string? part1, string? part2) GenerateSolutions();
    }
}
