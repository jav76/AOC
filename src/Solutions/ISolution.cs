using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Solutions
{
    internal interface ISolution
    {
        public void Init(string inputText);
        public string Part1Solution();
        public string Part2Solution();
        public (string? part1, string? part2) GenerateSolutions();
    }
}
