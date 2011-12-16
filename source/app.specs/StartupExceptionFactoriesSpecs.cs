using System;
using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupExceptionFactories))]
  public class StartupExceptionFactoriesSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_creating_an_exception_for_a_dependency_creation : concern
    {
      Establish c = () =>
      {
        the_inner = new Exception();
      };

      Because b = () =>
        result = StartupExceptionFactories.dependency_creation_error(the_inner, typeof(int));

      It should_create_an_exception_that_has_the_correct_details = () =>
      {
        result.InnerException.ShouldEqual(the_inner);
        result.Message.ShouldContain(typeof(int).Name);
      };

      static Exception result;
      static Exception the_inner;
    }

    public class when_creating_an_exception_for_a_factory_not_registered : concern
    {
      Because b = () =>
        result = StartupExceptionFactories.factory_not_registered(typeof(int));

      It should_create_an_exception_that_has_the_correct_details = () =>
        result.Message.ShouldContain(typeof(int).Name);

      static Exception result;
    }

    public class when_creating_an_exception_for_a_startup_step_violation : concern
    {
      Establish c = () =>
      {
        inner = new Exception();
      };
      Because b = () =>
        result = StartupExceptionFactories.startup_step_violation(typeof(int),inner);

      It should_create_an_exception_that_has_the_correct_details = () =>
      {
        result.Message.ShouldContain(typeof(int).Name);
        result.InnerException.ShouldEqual(inner);
      };

      static Exception result;
      static Exception inner;
    }
  }
}