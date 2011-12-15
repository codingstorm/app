namespace app.codekata
{
    using System.Collections.Generic;

    public class Anagrams
    {
        IFindAnagrams anagram_finder;

        IParseFiles file_parser;

        public Anagrams() : this (new StubParseFiles(), new StubFindAnagrams()) {
        }

        public Anagrams(IParseFiles fileParser, IFindAnagrams anagramFinder)
        {
            file_parser = fileParser;
            anagram_finder = anagramFinder;
        }

        public IEnumerable<IEnumerable<string>> find_anagrams(IEnumerable<string> wordsToFindAnagramsFor)
        {
            return anagram_finder.find_angarams(wordsToFindAnagramsFor, file_parser.fetch_all_words());
        }
    }
}