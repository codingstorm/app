namespace app
{
    using System.Collections.Generic;

    public interface IParseFiles
    {
        IEnumerable<string> fetch_all_words();
    }

    class StubParseFiles : IParseFiles
    {
        public IEnumerable<string> fetch_all_words()
        {
            return new List<string>();
        }
    }
}