using System.Web;
using System.Web.Compilation;
using app.web.core;
using app.web.core.aspnet;

namespace app.tasks.startup.steps
{
  public class ConfigureCustomFrontControllerMechanisms : IRunAStartupStep
  {
    IRegisterItemsInTheContainer registration;

    public ConfigureCustomFrontControllerMechanisms(IRegisterItemsInTheContainer registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      registration.register<IProcessRequests, FrontController>(options =>
      {
        options.register_polymorphically();
        options.as_singleton();
        options.decorate_with<TimedFrontController>();
      });
      registration.register<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
      registration.register<GetTheCurrentHttpContext>(() => HttpContext.Current);
    }
  }
}