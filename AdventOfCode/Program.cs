namespace AdventOfCode
{
    class Program
    {
        const char CheckmarkChar = '✓';
        const char UncheckedChar = '✗';

        static void Main(string[] args)
        {
            var puzzle = new Day2.Puzzle1();

            puzzle.Solve();
        }
    }
}
