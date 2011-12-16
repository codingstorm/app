using System;
using app.infrastructure;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using app.infrastructure.logging.simple;

namespace app.tasks.startup.steps
{
  public class ConfiguringInfrastructureServices : IRunAStartupStep
  {
    IRegisterItemsInTheContainer registration;

    public ConfiguringInfrastructureServices(IRegisterItemsInTheContainer registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      var container = new SimpleContainer(new DependencyFactories(registration, StartupExceptionFactories.factory_not_registered),
                                                 StartupExceptionFactories.dependency_creation_error);

      ContainerFacadeResolver resolver = () => container;
      Container.facade_resolver = resolver;
      registration.register<IFetchDependencies>(container);
      registration.register<CreateLoggingWriter>(() => Console.Out);
      registration.register(LoggingFormats.simple);
      registration.register<ICreateLoggers, TextWriterLoggerFactory>();
    }
  }
}