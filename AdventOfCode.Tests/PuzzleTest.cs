using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests
{
    public interface PuzzleTest
    {
        [TestMethod]
        void SolvePuzzle();
    }
}
