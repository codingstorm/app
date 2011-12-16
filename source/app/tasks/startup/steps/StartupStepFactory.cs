using System;

namespace app.tasks.startup.steps
{
  public class StartupStepFactory : ICreateAStartupStep
  {
    IRegisterItemsInTheContainer registration;
    StartupStepPolicyViolationExceptionFactory exception_factory;

    public StartupStepFactory(IRegisterItemsInTheContainer registration,StartupStepPolicyViolationExceptionFactory exception_factory)
    {
      this.registration = registration;
      this.exception_factory = exception_factory;
    }

    public IRunAStartupStep create_step_from(Type step_type)
    {
      try
      {
        return (IRunAStartupStep) Activator.CreateInstance(step_type, registration);
      }
      catch (Exception e)
      {
        throw exception_factory(step_type, e);
      }
    }
  }
}