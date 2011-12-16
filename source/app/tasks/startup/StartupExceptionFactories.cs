using System;
using app.infrastructure;
using app.infrastructure.containers.simple;
using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public class StartupExceptionFactories
  {
    public static ItemCreationExceptionFactory dependency_creation_error = (inner,type) =>
      new NotImplementedException("There was an error attempting to create a {0}".format(type.Name), inner);

    public static FactoryMissingExceptionFactory factory_not_registered = type =>
        new NotImplementedException("There is no factory registered that can create {0}".format(type.Name));

    public static StartupStepPolicyViolationExceptionFactory startup_step_violation = (type, inner) =>
      new NotImplementedException("The type {0} does not follow the policy for being a startup step".format(type.Name),inner);

  }
}