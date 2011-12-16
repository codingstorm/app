using System;
using System.Collections.Generic;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public static class Start
  {
    public static StartupChainBuilderFactory factory_resolver = step_type =>
    {
      var dependency_provider = new DependencyFactoriesProvider(new GreediestCtorSelection(), new LazyContainer());
      var registration = new ContainerRegistration(new List<ICreateASingleDependency>(), dependency_provider);
      return new StartupChainBuilder(new List<Type>(), step_type,new StartupStepFactory(registration,StartupExceptionFactories.startup_step_violation));
    };

    public static ICreateStartupChains by<AStartupStep>() where AStartupStep : IRunAStartupStep
    {
      return factory_resolver(typeof(AStartupStep));
    }
  }
}