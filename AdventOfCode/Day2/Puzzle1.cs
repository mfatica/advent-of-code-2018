using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day2
{
    public class Puzzle1 : Puzzle<string[], int>
    {
        public int ExpectedResult => 7410;

        public int Solve(string[] input)
        {
            int exactlyTwo = 0;
            int exactlyThree = 0;
            
            foreach(var boxId in input)
            {
                int[] characterOccurances = new int[26];

                bool hasExactlyTwo = false;
                bool hasExactlyThree = false;

                foreach(var c in boxId.ToLower())
                {
                    characterOccurances[c - 'a']++;
                }

                for(int i = 0; i < characterOccurances.Length; i++)
                {
                    if (hasExactlyTwo && hasExactlyThree)
                        break;

                    hasExactlyTwo = characterOccurances[i] == 2 || hasExactlyTwo;
                    hasExactlyThree = characterOccurances[i] == 3 || hasExactlyThree;
                }

                if (hasExactlyTwo)
                    exactlyTwo++;
                if (hasExactlyThree)
                    exactlyThree++;
            }

            return exactlyTwo * exactlyThree;
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
