using AdventOfCode.Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AdventOfCode.Tests.Day2
{
    [TestClass]
    public class Puzzle2Tests : PuzzleTest<Puzzle2, string[], string>
    {
        [TestMethod]
        public void SolveTestInput()
        {
            string[] input =
@"abcde
fghij
klmno
pqrst
fguij
axcye
wvxyz".Split(Environment.NewLine);

            SolvePuzzle(input, "fgij");
        }

        [TestMethod]
        public void Solve_DifferenceAtEndOfString()
        {
            string[] input =
@"abcde
fghij
klmno
pqrst
fghik
axcye
wvxyz".Split(Environment.NewLine);

            SolvePuzzle(input, "fghi");
        }

        [TestMethod]
        public void Solve_DifferenceAtStartOfString()
        {
            string[] input =
@"abcde
fghij
klmno
pqrst
qghij
axcye
wvxyz".Split(Environment.NewLine);

            SolvePuzzle(input, "ghij");
        }

        [TestMethod]
        public void TrieDictionary_CanAddAndRetrieve()
        {
            var dict = new TrieDictionary();

            dict['b'] = new Node
            {
                IsEndNode = true
            };

            Assert.IsTrue(dict['b'].IsEndNode);
            Assert.IsTrue(dict.ContainsKey('b'));

            Assert.AreEqual(1, dict.Keys.Count());
            Assert.AreEqual('b', dict.Keys.Single());
        }

        [TestMethod]
        public void TrieDictionary_CanAddAndRetrieve_MultipleKeys()
        {
            var dict = new TrieDictionary();

            dict['b'] = new Node
            {
                IsEndNode = true
            };

            dict['a'] = new Node
            {
                IsEndNode = true
            };

            Assert.IsTrue(dict.ContainsKey('a'));
            Assert.IsTrue(dict.ContainsKey('b'));

            Assert.AreEqual(2, dict.Keys.Count());

            CollectionAssert.AreEqual(new char[] { 'b', 'a' }, dict.Keys.ToArray());
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanAdd()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetWords()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            var words = trie.GetWords();

            Assert.AreEqual(1, words.Count());
            Assert.AreEqual("abc", words.Single());
        }

        [TestMethod]
        public void SimpleOneSkipTrie_DoesNotReturnSubwords()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            var words = trie.GetWords();

            Assert.IsFalse(words.Contains("a"));
            Assert.IsFalse(words.Contains("ab"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetWords_Many()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");
            trie.Add("def");

            var words = trie.GetWords();

            Assert.AreEqual(2, words.Count());
            CollectionAssert.AreEqual(new string[] { "abc", "def" }, words.ToArray());
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetWords_MultipleChildren()
        {
            var trie = new SkipOneTrie();

            trie.Add("a");
            trie.Add("ab");
            trie.Add("ad");
            trie.Add("abc");
            trie.Add("ade");

            var words = trie.GetWords();

            Assert.AreEqual(5, words.Count());
            CollectionAssert.AreEqual(new string[] { "a", "ab", "abc", "ad", "ade" }, words.ToArray());
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanSearch_EndWordOnly()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            Assert.IsTrue(trie.Contains("abc"));
            Assert.IsFalse(trie.Contains("a"));
            Assert.IsFalse(trie.Contains("ab"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanSearch_NoWords_ReturnsFalse()
        {
            var trie = new SkipOneTrie();
            
            Assert.IsFalse(trie.Contains("a"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetSimiliar_CanGetSameString()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            Assert.AreEqual("abc", trie.GetSimilar("abc"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetSimiliar_SimiliarWordExists_DifferentAtStart_ReturnsSimiliarString()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            Assert.AreEqual("bc", trie.GetSimilar("dbc"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetSimiliar_SimiliarWordExists_DifferentInMiddle_ReturnsSimilarString()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            Assert.AreEqual("ac", trie.GetSimilar("adc"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetSimiliar_SimiliarWordExists_DifferentAtEnd_ReturnsSimilarString()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            Assert.AreEqual("ab", trie.GetSimilar("abd"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetSimiliar_SimilarWordIsLonger_ReturnsNull()
        {
            var trie = new SkipOneTrie();

            trie.Add("abc");

            Assert.IsNull(trie.GetSimilar("a"));
            Assert.IsNull(trie.GetSimilar("b"));
            Assert.IsNull(trie.GetSimilar("ab"));
        }

        [TestMethod]
        public void SimpleOneSkipTrie_CanGetSimiliar_NoWords_ReturnsNull()
        {
            var trie = new SkipOneTrie();

            Assert.IsNull(trie.GetSimilar("a"));
        }
    }
}
