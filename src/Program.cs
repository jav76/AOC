
using System.Text;

namespace AOC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short currentYear = 2023;
            short? currentDay = null;

            while (true)
            {
                (currentDay, currentYear) = MenuSelection(currentDay, currentYear);
            }

        }

        private static (short? newDay, short newYear) MenuSelection(short? day, short year)
        {
            var menuResult = (day, year);

            //Console.Clear();

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
                            Console.Clear();
                            menuResult.year = GetSelection(MenuSelectionEnum.Year);
                            break;

                        case 2:
                            Console.Clear();
                            menuResult.day = GetSelection(MenuSelectionEnum.Day);
                            break;

                        case 3:
                            if (day.HasValue)
                            {
                                Console.WriteLine(AOCHelper.GenerateSolution(day.Value, 1, year));
                            }
                            else
                            {
                                Console.Write("Day must be selected first.");
                            }
                            break;

                        case 4:
                            if (day.HasValue)
                            {
                                Console.WriteLine(AOCHelper.GenerateSolution(day.Value, 2, year));
                            }
                            else
                            {
                                Console.Write("Day must be selected first.");
                            }
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                }
            }

            return menuResult;
        }

        private enum MenuSelectionEnum
        {
            Day = 1,
            Year = 2
        }

        private static short GetSelection(MenuSelectionEnum selection)
        {
            short result = 0;
            Console.WriteLine
            (
                selection == MenuSelectionEnum.Day
                    ? "Enter day selection:\n"
                    : "Entry year selection:\n"
            );
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (short.TryParse(input, out result) && result >= 1)
                {
                    return result;
                }
                else
                {
                    return GetSelection(selection);
                }
            }
            else
            {
                return GetSelection(selection);
            }
        }
    }
}