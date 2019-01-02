using AdventOfCode.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Day1
{
    [TestClass]
    public class Puzzle2Tests : PuzzleTest<Puzzle2, int[], int>
    {
        readonly Puzzle2 puzzle = new Puzzle2();
        readonly SimpleBinarySearchTree searchTree = new SimpleBinarySearchTree();

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
