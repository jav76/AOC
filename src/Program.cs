
using System.Text;

namespace AOC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short currentYear = 2022;
            short? currentDay = null;

            while (true)
            {
                MenuSelection(currentDay, currentYear);
            }

        }

        private static (short? newDay, short newYear) MenuSelection(short? day, short year)
        {
            var menuResult = (day, year);

            Console.Clear();

            Console.WriteLine($"Advent of code {year} - Day {(day.HasValue ? day.Value : "[None]")}\n");
            
            StringBuilder sb = new StringBuilder();
            sb.Append("1) Change year selection.\n");
            sb.Append("2) Change day selection.\n");
            sb.Append("3) Generate Part 1 solution.\n");
            sb.Append("4) Generate Part 2 solution.\n");
            sb.Append("5) Quit.\n");

            Console.Write(sb.ToString());

            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                short selection;
                if (short.TryParse(input, out selection) && selection >= 1 && selection <= 5)
                {
                    switch (selection)
                    {
                        case 1:
                            menuResult.year = GetYearSelection(); // todo
                            break;

                        case 2:
                            menuResult.day = GetDaySelection(); // todo
                            break;

                        case 3:
                            if (day.HasValue)
                            {
                                GenerateSolution(day.Value, 1, year); // todo
                            }
                            break;

                        case 4:
                            if (day.HasValue)
                            {
                                GenerateSolution(day.Value, 2, year); // todo
                            }
                            break;

                        case 5:
                            System.Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                }
            }

            return menuResult;
        }
    }
}