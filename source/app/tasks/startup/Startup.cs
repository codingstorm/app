namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      Start.by_running_steps_defined_in("startup_steps.txt");
    }
  }
}