using AdventOfCode.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.Day1
{
    [TestClass]
    public class Puzzle2Tests : PuzzleTest
    {
        readonly Puzzle2 puzzle = new Puzzle2();
        readonly SimpleBinarySearchTree searchTree = new SimpleBinarySearchTree();

        [TestMethod]
        public void SolvePuzzle()
        {
            const int expectedFrequency = 72889;
            var frequency = puzzle.Solve();
            Assert.AreEqual(expectedFrequency, frequency);
        }

        [TestMethod]
        public void SimpleBinarySearchTree_CanSearch()
        {
            var wasOneSeen = searchTree.WasSeen(1);
            Assert.IsFalse(wasOneSeen);

            var wasOneSeenAgain = searchTree.WasSeen(1);
            Assert.IsTrue(wasOneSeenAgain);

            var wasTwoSeen = searchTree.WasSeen(2);
            Assert.IsFalse(wasTwoSeen);
        }
    }
}
