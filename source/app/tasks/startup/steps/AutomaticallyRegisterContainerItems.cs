namespace app.tasks.startup.steps
{
  public class AutomaticallyRegisterContainerItems : IRunAStartupStep
  {
    IRegisterItemsInTheContainer registration;

    public AutomaticallyRegisterContainerItems(IRegisterItemsInTheContainer registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      throw new System.NotImplementedException();
    }
  }
}