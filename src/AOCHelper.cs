using AOC.Solutions;
using System.Runtime.Remoting;

namespace AOC
{
    internal class AOCHelper
    {
        protected AOCHelper() { }

        public static string GenerateSolution(short day, short part, short year)
        {
            string? assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            ObjectHandle? solutionHandler = Activator.CreateInstance(assembly ?? string.Empty, $"AOC.Solutions._{year}.Day{day}");
            if (solutionHandler != null)
            {
                ISolution? solutionInstance = solutionHandler.Unwrap() as ISolution;
                if (solutionInstance == null)
                {
                    return string.Empty;
                }

                solutionInstance.Init(AOCRepo.GetInput(day, year).Result);
                (string? part1, string? part2) = solutionInstance.GenerateSolutions();

                switch (part)
                {
                    case 1:
                        return $"Part 1 solution: {part1 ?? string.Empty}";

                    case 2:
                        return $"Part 2 solution: {part2 ?? string.Empty}";

                    default:
                        Console.WriteLine("Invalid solution part.");
                        return string.Empty;
                }
            }
            else
            {
                Console.WriteLine($"Unable to create solution instance {assembly}.{year}.{day}");
                return string.Empty;
            }
        }
    }
}
