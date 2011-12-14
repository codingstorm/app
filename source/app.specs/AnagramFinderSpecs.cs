namespace app.specs
{
    using Machine.Specifications;

    public abstract class concern 
    {
         
    }

    public class when_anagram_finder_is_asked_to_find_anagrams : concern
    {
        Establish context = () =>
            {
                
            }; 

        Because of = () => sut.find_for();

        It should_return_a_list_of_enagrams = () =>  
    }

}