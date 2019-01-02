using AdventOfCode.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.Day1
{
    [TestClass]
    public class Puzzle1Tests
    {
        readonly Puzzle1 puzzle = new Puzzle1();

        [TestMethod]
        public void SolvePuzzle()
        {
            const int expectedFrequency = 518;
            var frequency = puzzle.Solve();
            Assert.AreEqual(expectedFrequency, frequency);
        }
    }
}
