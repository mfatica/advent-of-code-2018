using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCode.Tests
{
    public abstract class PuzzleTest<TPuzzle, TInput, TResult> where TPuzzle : Puzzle<TInput, TResult>
    {
        [TestMethod]
        public void SolvePuzzle()
        {
            var puzzle = (TPuzzle)Activator.CreateInstance(typeof(TPuzzle));
            var actualResult = puzzle.Solve();
            Assert.AreEqual(puzzle.ExpectedResult, actualResult);
        }
        
        protected void SolvePuzzle(TInput testInput, TResult expected)
        {
            var puzzle = (TPuzzle)Activator.CreateInstance(typeof(TPuzzle));
            var actualResult = puzzle.Solve(testInput);
            Assert.AreEqual(expected, actualResult);
        }
    }
}
