using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        const char CheckmarkChar = '✓';
        const char UncheckedChar = '✗';

        static void Main(string[] args)
        {
            //var projectDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
            //var dayDirectories = Directory.GetDirectories(projectDirectory, "Day*");

            //var daysAndPuzzlesGroupedByNamespace = Assembly.GetExecutingAssembly()
            //    .DefinedTypes
            //    .Where(dt => dt.Namespace.StartsWith("AdventOfCode.Day"))
            //    .GroupBy(dt => dt.Namespace);


            //// Looks like this:
            //// Day 1:
            ////   Puzzle 1 ✓ 
            ////   Puzzle 2 ✗
            ////
            //// Day 2:
            ////   Puzzle 1 ✗ 
            ////   Puzzle 2 ✗
            //foreach (var dayAndPuzzleGroup in daysAndPuzzlesGroupedByNamespace)
            //{
            //    Console.WriteLine("");
            //}
        }
    }
}
