using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.infrastructure.containers;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
    [Subject(typeof(StoryUrlSpecs))]
    public class StoryUrlSpecs
    { 
        public abstract class concern : Observes
        {
        }

        public class when_doing_something_with_a_story_url : concern
        {
            Establish c = () =>
            {

            };

            Because b = () =>
            {

            };

            It should_do_something_in_particular = () =>
            {

            };
        }
    }
}
