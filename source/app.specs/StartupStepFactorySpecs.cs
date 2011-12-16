using System;
using System.Collections;
using System.Collections.Generic;
using Machine.Specifications;
using app.infrastructure.containers.simple;
using app.tasks.startup;
using app.tasks.startup.steps;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupStepFactory))]
  public class StartupStepFactorySpecs
  {
    public abstract class concern : Observes<ICreateAStartupStep,
                                      StartupStepFactory>
    {
    }

    public class when_creating_a_startup_step : concern
    {
      public class that_follows_the_convention_for_a_startup_step : when_creating_a_startup_step
      {
        Establish c = () =>
        {
          registration = new FakeRegistration();
          depends.on(registration);
        };

        Because b = () =>
          result = sut.create_step_from(typeof(FirstStep));

        It should_return_the_step_with_its_dependencies_met = () =>
        {
          var item = result.ShouldBeAn<FirstStep>();
          item.registration.ShouldNotBeNull();
          item.registration.ShouldEqual(registration);
        };

        static IRunAStartupStep result;
        static IRegisterItemsInTheContainer registration;
      }

      public class that_does_not_follow_the_startup_convention : when_creating_a_startup_step
      {
        Establish c = () =>
        {
          custom_exception = new Exception();
          depends.on<StartupStepPolicyViolationExceptionFactory>((type,inner) =>
          {
            inner.ShouldNotBeNull();
            type.ShouldEqual(typeof(SecondStep));
            return custom_exception;
          });
          registration = new FakeRegistration();
          depends.on(registration);
        };

        Because b = () =>
          spec.catch_exception(() => sut.create_step_from(typeof(SecondStep)));

        It should_throw_the_exception_created_by_the_policy_factory = () =>
          spec.exception_thrown.ShouldEqual(custom_exception);

        static IRegisterItemsInTheContainer registration;
        static Exception custom_exception;
      }

      public class FakeRegistration : IRegisterItemsInTheContainer
      {
        public IEnumerator<ICreateASingleDependency> GetEnumerator()
        {
          return new List<ICreateASingleDependency>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
          return GetEnumerator();
        }

        public void register<Implementation>()
        {
          throw new NotImplementedException();
        }

        public void register<Contract, Implementation>() where Implementation : Contract
        {
          throw new NotImplementedException();
        }

        public void register<Dependency>(Dependency instance)
        {
          throw new NotImplementedException();
        }
      }

      public class SecondStep : IRunAStartupStep
      {
        public IRegisterItemsInTheContainer registration;

        public void run()
        {
          throw new NotImplementedException();
        }
      }
      public class FirstStep : IRunAStartupStep
      {
        public IRegisterItemsInTheContainer registration;

        public FirstStep(IRegisterItemsInTheContainer registration)
        {
          this.registration = registration;
        }

        public void run()
        {
          throw new NotImplementedException();
        }
      }
    }
  }
}