using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day2
{
    public class Node
    {
        public TrieDictionary Children { get; set; }
            = new TrieDictionary();

        public bool IsEndNode { get; set; }
            = false;
    }

    public class TrieDictionary : IEnumerable<KeyValuePair<char, Node>>
    {
        private LinkedList<char> _keys = new LinkedList<char>();
        private Node[] _values = new Node[26];

        private bool isValidKey(char c) => c >= 'a' && c <= 'z';

        public IEnumerable<char> Keys => _keys;

        public bool ContainsKey(char key)
        {
            if (!isValidKey(key))
                return false;

            return !(_values[key - 'a'] == null);
        }

        public IEnumerator<KeyValuePair<char, Node>> GetEnumerator()
        {
            for(int i = 0; i < _values.Length; i++)
            {
                yield return new KeyValuePair<char, Node>((char)(i + 'a'), _values[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Node this[char key]
        {
            get
            {
                if (!isValidKey(key))
                    throw new ArgumentException($"Key '{key}' is out of bounds");

                return _values[key - 'a'];
            }
            set
            {
                if (!isValidKey(key))
                    throw new ArgumentException($"Key '{key}' is out of bounds");

                // if this is the first time we're using this key
                // add it to our linked list so we can iterate
                // through our keys
                if(_values[key - 'a'] == null)
                {
                    _keys.AddLast(key);
                }

                _values[key - 'a'] = value;
            }
        }
    }
    
    public class SkipOneTrie
    {
        Node _root = new Node();

        public void Add(string s)
        {
            Node current = _root;
            
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (current.Children.ContainsKey(c))
                    current = current.Children[c];
                else
                    current = current.Children[c] = new Node { };

                // if we're on the last letter
                if (i == s.Length - 1)
                    current.IsEndNode = true;
            }
        }

        public bool Contains(string s)
        {
            Node current = _root;

            int i = 0;

            do
            {
                var c = s[i];

                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }

                current = current.Children[c];

                i++;
            } while (i < s.Length);

            return current.IsEndNode;
        }

        public string GetSimilar(string s)
        {
            return GetSimilar(_root, s, 0, true, "");
        }

        string GetSimilar(Node current, string s, int pos, bool canSkip, string similar)
        {
            // if we're at the end
            if (pos >= s.Length)
                return current.IsEndNode ? similar : null;

            var c = s[pos];

            if (current.Children.ContainsKey(c))
                return GetSimilar(current.Children[c], s, pos + 1, canSkip, similar + c);

            if(canSkip)
            {
                foreach (var key in current.Children.Keys)
                {
                    var similarChild = GetSimilar(current.Children[key], s, pos + 1, false, similar);
                    if (similarChild != null)
                        return similarChild;
                }
            }

            return null;
        }

        public IEnumerable<string> GetWords()
        {
            return GetWords(_root, "");
        }

        public IEnumerable<string> GetWords(Node current, string word)
        {
            if(current.IsEndNode)
            {
                yield return word;
            }

            foreach(var key in current.Children.Keys)
            foreach(var nextWord in GetWords(current.Children[key], word + key))
            {
                    yield return nextWord;
            }
        }
    }

    public class Puzzle2 : Puzzle<string[], string>
    {
        public string ExpectedResult => "cnjxoritzhvbosyewrmqhgkul";

        // Trie solution
        // Works with test input but not the actual input
        // Not sure why
        //public string Solve(string[] input)
        //{
        //    var trie = new SkipOneTrie();

        //    foreach(var boxId in input)
        //    {
        //        var similar = trie.GetSimilar(boxId);

        //        if (similar != null)
        //            return similar;

        //        trie.Add(boxId);
        //    }

        //    return null;
        //}

        public string Solve(string[] input)
        {
            foreach(var x in input)
            {
                foreach(var y in input)
                {
                    int diff = 0;

                    for(int i = 0; i < x.Length; i++)
                    {
                        if (x[i] != y[i])
                            diff++;
                    }

                    if (diff == 1)
                    {
                        var sb = new StringBuilder();
                        for(int i = 0; i < x.Length; i++)
                        {
                            if (x[i] == y[i])
                                sb.Append(x[i]);
                        }
                        return sb.ToString();
                    }
                }
            }

            return null;
        }

        public string[] Input =>
@"cnjxpritdzhubeseewfmqagkul
cwyxpgitdzhvbosyewfmqagkul
cnfxpritdzhebosywwfmqagkul
cnjxpritdzgvbosyawfiqagkul
cnkxpritdzhvbosyewfmgagkuh
gnjxprhtdzhebosyewfmqagkul
cnjxpriedzevbosyewfjqagkul
cnjxpritdzhpyosyewfsqagkul
cnjxprltdzhvbosyewfmhagkzl
cnjxfritdjhvbosyewfmiagkul
xnjxpritdzhvbosyewfmqagkgn
cnjxpritdzmvzosyewfhqagkul
cljxxritdzhvbosyewfmragkul
cnjxjritdzhvbovyewfmvagkul
cnjxprdtdzhpbosyewvmqagkul
cojxprdtdzhzbosyewfmqagkul
cnjxpritgzhvfgsyewfmqagkul
knjxprptdzhvbosyecfmqagkul
cnjxpritdzhvbvsyeyfmqagkuc
cnjxpritdzhvbosvewfmoagjul
cnjxpritdzhvbosyfwfmbagkjl
cnjxpjitazhvbosfewfmqagkul
cnjtpfitdzhvbosyewfmiagkul
ckjxpritdzhvbysyewfmqagoul
cnjxvritdzhvbfsyewfmqalkul
cnjipqitdzhvbosyewfeqagkul
cnjhpritdzhvbosyewymqjgkul
cnjxprrtdzhvbosyewfmlkgkul
cnjxnritdzhvbopyewfmqaskul
cxjxpritdzhvtosyewjmqagkul
cnjxpritdzhvbjsyewfrqagkwl
cnjxhritdzhubosyewfmqagvul
cnjxpritdzhvbosyyyfmeagkul
cnjxkritdzhvaoeyewfmqagkul
cnjxpritdzhvtotyewfmqazkul
cnjxoriadzhvbosyewfmqcgkul
cnjxpritdzhcbosyewfmkapkul
fnjxprtddzhvbosyewfmqagkul
cnjxmvitdzhvbosyewfmqagrul
cnjxpyitdzhibosyewfmqagktl
cyjxprxtdzhvbosyewbmqagkul
onjxpditdzhvbosyeofmqagkul
cnjxprixdzhvbosuewftqagkul
cnjxpritdrhvaosyewymqagkul
cnjxpritdzhhbokyewfvqagkul
cnjxpritczhvbosyewfmqwgxul
cnjxpribdzqvbnsyewfmqagkul
ynpxpritdzhvbvsyewfmqagkul
cnjxprirdzhvboerewfmqagkul
cnjxpritdxhvbosyewfmgavkul
cnwxprntdzhvbosyewfmqagkuk
cnjxpritzzhvbosyewfmcagktl
bbjxpritdzhvbosyetfmqagkul
cnjxpbitdzhvbosyewrmqagkui
cnjxwrildzcvbosyewfmqagkul
cnqxpoitdzhvbosnewfmqagkul
cnzxpritdzhvbosyewfmqazkfl
cnjxpriddzhvoosyewfmhagkul
znjxpritdzhvbosjewfmqagkur
cnjxpritdzhvbosyewcmfagkuk
cnjxpritdzhvbomyywnmqagkul
cnjxpgitjzhvbosyejfmqagkul
cnjxpkitdzjvbosyewfmqcgkul
cnjxpritduhvbosyewfmqfkkul
cnfxpritdzhvbgsyewfmqwgkul
cnjxpritdzhvbosywufmqaskul
cnjxprittzhvboryswfmqagkul
cndxpritpzrvbosyewfmqagkul
cnjxpritdzhvbosyewfwqazkum
cccxprmtdzhvbosyewfmqagkul
cnjxpzitdzhvlbsyewfmqagkul
cnjxdrigdzhvbosyewfmqagsul
fhjxpritdzhvbosyewfmqagkcl
cnjxpritdzhvdosyewffqagaul
cnjxprikdztvbosyekfmqagkul
cnjxpritdzhvbohiewfmqagkue
cnjxpritdzhvbowyetfmqegkul
cnuxpritdzhvbosyewmmqapkul
qnjxpritdzhvbosyewfmjakkul
cnjxpritdzlvbosyewiaqagkul
cnjxpritdzhpoosyewfmvagkul
cdjxpritdzhvboryewfbqagkul
cnjxppitxzhvbosyewymqagkul
cnjxpywtdzhvboiyewfmqagkul
cnjxpritdzpvbosyezfmqaqkul
cnjppritdghvbosyewfdqagkul
cmjxpritdzhvbosvewfmqagkup
cnjxoritdzhvbosylffmqagkul
cnjxfritdzhvbojyewfmqagkvl
cnjxpritdzhvbozyewgmqlgkul
cnjxlritdzhvbosyewfmqalkug
cnyxprittzhvbosyewfmsagkul
cnjxprytdzcvdosyewfmqagkul
ctjxpritdzhvbosyedfmqagkil
cnjxpvitdzhrbosyewfmqaekul
cnyxyritdzhvbospewfmqagkul
cnjxoritwzhvbosyewrmqhgkul
cnjxpritdzhjbosyqwsmqagkul
cnjzprindzhvbosyewfmqabkul
cnjspritdzhvbosysffmqagkul
cnxxpritdzhvbosyelfmqageul
bnjhpritdzhvbosyewfmzagkul
cnjxbhitdzhdbosyewfmqagkul
cnjxprktdzmvbosyewfmqagkuj
cnjxprixdzhvbqsyewfmqmgkul
cnjxpkitdzhvbosyewfmqagbum
cnjhpritdzhxbosyewfmqagjul
cnjxpritdzzvbosyewuqqagkul
cnjxprhtdzhvuopyewfmqagkul
cnjxpritdzhjqosyewfmqagkgl
cnzxpritdzhvbosyejfmuagkul
cnvxpritoohvbosyewfmqagkul
cnjxpmitdzwvbosyemfmqagkul
cnjoprittzzvbosyewfmqagkul
cnjxpgitdzhvbosytwfmqsgkul
cnjxprrtdehvbosyewfnqagkul
onjxpjitdzgvbosyewfmqagkul
cnjxpmitdzhvbopaewfmqagkul
cnjxpritqzhvbosoewfrqagkul
cnjxpnitdzhvbosyewfmqagkjy
cnsxpritdzhvbosyewfmqjykul
cnjxpriidzhvbosyewfmqxgkut
cnjxpyitdzhnbosyewfgqagkul
cnjxpritdzhbboyyewfmqagsul
cnjxpeitdzsvbosyewfmqabkul
cnjxpritdzhzvosyewfmragkul
cnjrpritdzhmbosyewfmqrgkul
cnjxpritdzhmbosyenfmqaglul
cnjxqrntdzhvboswewfmqagkul
cnjxprdtpzhvbosyewfmqagkcl
cnjxpritdzhvsdsyewfmqagkur
cnjxpritdzhvvosyewumqhgkul
cnzxpritdznvhosyewfmqagkul
ynjypritdzhvbosyewfmqagkuz
cnjxpnitdzhvbocyezfmqagkul
vnjxpritdzhvbfsyewfmjagkul
cnjfpritdzhvbosyewfmqagkzu
cnjxpritdzhbbosyewfmlegkul
cnjxpnitdzhvbosyesfmbagkul
cnjxpritezwvbosyewfmqagkgl
cujxpritdzhqbosyawfmqagkul
cnjxprindzhrbosyerfmqagkul
cntxpritdzhvbosyewfmqauxul
cnjxpvitdzhvbosyepfmqagkuy
cnjxdrqtdzhvbosdewfmqagkul
cnnxpritdzhvvosyenfmqagkul
lnjxphitdzhvbosyewfaqagkul
cngxpritdzhhbobyewfmqagkul
uncxphitdzhvbosyewfmqagkul
cnjxpribdehvbosfewfmqagkul
cnjxppitdqhvbmsyewfmqagkul
gnjxpritkzhvbosyewfbqagkul
znjxpritdzhvbowycwfmqagkul
cnjxpgitdzhvbosyewidqagkul
cnjxhritdzhvbowyswfmqagkul
injxkritdzhvbjsyewfmqagkul
cmjupritgzhvbosyewfmqagkul
cnjxpritdzbvjoeyewfmqagkul
cnjxpritdkhvbosyewlmuagkul
cnkxpritdzhebvsyewfmqagkul
cyjxptitdzhvbosyewfmqagkuv
cnjxpritdzhvbodrewflqagkul
cnjxpratdzhvbksyewfhqagkul
cnjxpoitdzhvbosjewxmqagkul
cnjxprhidzhvbasyewfmqagkul
cnjxpritdzhvbosqewvmqagmul
cnjxoritdzhvbosyzifmqagkul
mnjxpritdzhvbcsyeyfmqagkul
cnjhpritgzhvbosyewfmqngkul
cnjxprijdzevbesyewfmqagkul
cnexprqtdzhvbosyewvmqagkul
cnjxpxitdzhvbosyawfmqmgkul
cnjxpritdzhvbosyirfmqaxkul
cqjxpcitdzhvboslewfmqagkul
cmjxpqitdztvbosyewfmqagkul
cnbxpritdzhvfosyewfmuagkul
cnjxprrtdzhvbosumwfmqagkul
cnjxprttdvhvbossewfmqagkul
cnjxpritdzhvbcsuewfaqagkul
cbjxpritdzhvbosyewfhqalkul
cnjxprithzhvbosjcwfmqagkul
chjxpritdzhvbosyewftcagkul
cnjxprirdchvdosyewfmqagkul
cnjxpritdxhvbosyewfmqcgkal
cnjxpriidchvbosrewfmqagkul
cnjhprizdzhvbosyewfmqagvul
cnjwpritdzhpbosyewfmqaqkul
cnjxpgitfzhvbosyxwfmqagkul
cnjxpjiedzhvbosywwfmqagkul
cnjxpritdzhvbosyewfpqynkul
xnixlritdzhvbosyewfmqagkul
cnjxoritdznvbosyehfmqagkul
cnjxpritdzhvbjsyewsmqagcul
lnjxpritdzhvkosyewjmqagkul
cnjxpritdzhvbosyedfiqvgkul
cnjxpritdzhqbdsyerfmqagkul
cnjxpritdzavbosyywfmqagvul
dmjxprithzhvbosyewfmqagkul
cnjxpriqdzhvnosyeofmqagkul
cnjxpritdxhvboszewfmqkgkul
cnjxpritdzxvbosjewymqagkul
cnjxpritdzngbosyewfmqugkul
cajxpritdnhvbosyerfmqagkul
cnsxpritdzhvbosymwfmqagcul
cnjxoritdzhvbosyewrmqhgkul
cnjxpritdzhvposyewfmqagkwo
cnjxpriazzhvbosyeufmqagkul
cnjxrritdzhvbosymhfmqagkul
cnjxprztdzhvbosyewfmqtgkum
cnjxpritdzhvbmsyewfmqatkun
cnuxpritdzhvbosyewfmqagvur
ctjxxritdzhvbosyewfvqagkul
cnjxpritdzlvbosyevfmqagkll
cnjxpritdzhlbosyewfmqagasl
cnjxpritwzhvbosyewfcxagkul
cyjxpritdzhfbosyewfmqagcul
cnjxpritxghvkosyewfmqagkul
ctjxpritdjhvbosyewfmqkgkul
cnjxpritxzhvbosyewjmbagkul
unjxpritdzhkbosyewfmqaghul
cnjoprqtdzhvbosyewzmqagkul
rnjxprgtgzhvbosyewfmqagkul
cnjgpqitdzhvbosyewfaqagkul
cnjxpritdzuybosyewfmqagful
cnjxprqtdahvbosyewfnqagkul
cnjxpritdzhmkhsyewfmqagkul
wnjxpritdzhvbosiewfmqagkml
cnjmpritdzhvbosyjwfmqagkdl
cnjopritdzhvbksyewfmqrgkul
cnlxpritdzhvbosyewfmomgkul
cgjxpritdzhvbbsyewfmxagkul
cnaxpritdvhvnosyewfmqagkul
cnjxprijdzhvbkmyewfmqagkul
cnjxpritdzhvposyewzmqagkuz
cnuxpuitdzdvbosyewfmqagkul
cnjxprifdzjvbosyewfyqagkul
cnhspritdzhvbosyewfmqaghul
cnjxprcbdzfvbosyewfmqagkul
lnjapritdzhvbosyewfmqegkul
cnjxprisszhvbosyewqmqagkul
cnjxpritdzhvbosyeifmsagoul
cnjxpritrfhvbosyewfmqagkuz
cnjxkritdzmvboqyewfmqagkul
cnjxpritdzhvbosyedfmqzgkzl
cnjxprifdzhvbosyswfmqagksl
cnjxoritdzhvbosyxwfmhagkul
cnjhpritdzzvbosfewfmqagkul
cnjxprityjhvbomyewfmqagkul
cnjbpritdzhvbosyywfmqagkuf
cnjxprrtdzhvbosyewgmqagtul".Split(Environment.NewLine);
    }
}
