namespace app.infrastructure.containers.simple
{
  public class SimpleContainer : IFetchDependencies
  {
      IFindFactoriesThatCanCreateDependencies factory_finder;

      public SimpleContainer(IFindFactoriesThatCanCreateDependencies factoryFinder)
      {
          factory_finder = factoryFinder;
      }

      public Dependency an<Dependency>()
      {
          return (Dependency)factory_finder.get_factory_that_can_create(typeof(Dependency)).create();
      }
  }
}