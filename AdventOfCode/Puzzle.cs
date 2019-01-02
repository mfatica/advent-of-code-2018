using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public interface Puzzle<TInput, TResult>
    {
        TInput Input { get; }
        TResult Solve(TInput input);
    }

    public static class PuzzleExtensions
    {
        public static TResult Solve<TInput, TResult>(this Puzzle<TInput, TResult> puzzle)
        {
            return puzzle.Solve(puzzle.Input);
        }
    }
}
