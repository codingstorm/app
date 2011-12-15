namespace app.specs
{
    using System.Collections.Generic;

    using Machine.Specifications;

    using developwithpassion.specifications.rhinomocks;
    
    using app;
    using app.codekata;

    public abstract class concern : Observes<Anagrams>
    {
         
    }

    public class when_anagram_finder_is_asked_to_find_anagrams : concern
    {
        Establish context = () =>
            {
                words = new List<string> { "testone", "testtwo"};
                
                file_parser = depends.on<IParseFiles>();
                anagram_finder = depends.on<IFindAnagrams>();

            }; 

        Because of = () => result = sut.find_anagrams(words);

        It should_return_a_list_of_enagrams = () => result.ShouldNotBeEmpty();

        static IEnumerable<string> words;

        static IEnumerable<IEnumerable<string>> result;

        static IParseFiles file_parser;

        static IFindAnagrams anagram_finder;
    }
}