using Machine.Specifications;
using app.infrastructure.containers;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(LazyContainer))]
  public class LazyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      LazyContainer>
    {
    }

    public class when_fetching_dependencies : concern
    {
      Establish c = () =>
      {
        container_resolved_item = new TheItem();
        the_container_facade = fake.an<IFetchDependencies>();
        ContainerFacadeResolver resolver = () => the_container_facade;

        spec.change(() => Container.facade_resolver).to(resolver);
        the_container_facade.setup(x => x.an<TheItem>()).Return(container_resolved_item);
      };
      Because b = () =>
        result = sut.an<TheItem>();


      It should_return_dependencies_using_the_container_static_gateway = () =>
        result.ShouldEqual(container_resolved_item);

      static TheItem result;
      static TheItem container_resolved_item;
      static IFetchDependencies the_container_facade;
    }

    public class TheItem
    {
    }
  }
}