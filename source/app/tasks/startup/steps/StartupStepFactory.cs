using System;

namespace app.tasks.startup.steps
{
  public class StartupStepFactory : ICreateAStartupStep
  {
    IRegisterItemsInTheContainer registration;

    public StartupStepFactory(IRegisterItemsInTheContainer registration)
    {
      this.registration = registration;
    }

    public IRunAStartupStep create_step_from(Type step_type)
    {
      return (IRunAStartupStep) Activator.CreateInstance(step_type, registration);
    }
  }
}