using System.Text.RegularExpressions;

namespace AOC.Solutions._2024
{
    internal class Day3 : SolutionBase, ISolution
    {
        private const string INSTRUCTION_PATTERN = @"mul\(\d+,\d+\)";
        private const string ENABLED_INSTRUCTION_PATTERN = @"do\(\)|don't\(\)";
        private const string DIGIT_PATTERN = @"\d+";
        private const string DISABLE_INSTRUCTION = "don't()";

        public override string Part1Solution()
        {
            return ProcessInstructions(GetInstructions(InputText)).ToString();
        }

        public override string Part2Solution()
        {
            MatchCollection enabledInstructions = GetEnabledInstructions(InputText);
            Match lastMatch = enabledInstructions[0];
            List<string> removedInstructions = new();

            foreach (Match instruction in enabledInstructions)
            {
                if (lastMatch.Value == DISABLE_INSTRUCTION)
                {
                    removedInstructions.Add(InputText[lastMatch.Index..instruction.Index]);
                }
                lastMatch = instruction;
            }
            removedInstructions.Add(InputText[lastMatch.Index..]);

            string filteredInstructions = InputText;
            foreach (string instruction in removedInstructions)
            {
                filteredInstructions = filteredInstructions.Replace(instruction, string.Empty);
            }

            return ProcessInstructions(GetInstructions(filteredInstructions)).ToString();
        }

        private static MatchCollection GetInstructions(string instructionText)
        {
            return Regex.Matches(instructionText, INSTRUCTION_PATTERN);
        }

        private static MatchCollection GetEnabledInstructions(string instructionText)
        {
            return Regex.Matches(instructionText, ENABLED_INSTRUCTION_PATTERN);
        }

        private static int ProcessInstructions(MatchCollection instructions)
        {
            int result = 0;
            foreach (Match instruction in instructions)
            {
                var numbers = Regex.Matches(instruction.Value, DIGIT_PATTERN);
                if (numbers.Count == 2)
                {
                    result += int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value);
                }
            }
            return result;
        }
    }
}