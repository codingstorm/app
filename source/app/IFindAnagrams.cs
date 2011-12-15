namespace app
{
    using System.Collections.Generic;

    public interface IFindAnagrams
    {
        IEnumerable<IEnumerable<string>> find_angarams(IEnumerable<string> wordsToFindAnagramsFor, IEnumerable<string> words);
    }

    class StubFindAnagrams : IFindAnagrams
    {
        public IEnumerable<IEnumerable<string>> find_angarams(IEnumerable<string> wordsToFindAnagramsFor, IEnumerable<string> words)
        {
            return new List<IEnumerable<string>>()
                {
                    new string[]{""},
                };
        }
    }
}