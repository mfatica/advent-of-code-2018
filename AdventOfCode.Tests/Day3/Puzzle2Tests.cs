using AdventOfCode.Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCode.Tests.Day3
{
    [TestClass]
    public class Puzzle2Tests : PuzzleTest<Puzzle2, string[], int>
    {
        [TestMethod]
        public void TestInput()
        {
            SolvePuzzle(
@"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2".Split(Environment.NewLine), 3);
        }
    }
}
